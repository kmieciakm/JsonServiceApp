using JsonTestApp.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonTestApp.Services {
    public class JsonService {

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "data.json"); }
        }

        public JsonService( IWebHostEnvironment webHostEnvironment ) {
            WebHostEnvironment = webHostEnvironment;
        }

        public string ApplicationName { get { return WebHostEnvironment.ApplicationName; } }

        public IEnumerable<Product> GetProducts() {
            string jsonText = File.ReadAllText(JsonFileName);
            IEnumerable<Product> products = JsonSerializer.Deserialize<Product[]>(jsonText,
                new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                });
            return products;
            /*using (StreamReader jsonFileReader = File.OpenText(JsonFileName)) {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    });
            }*/
        }

        public void AddRating( string productId, int rate ) {
            IEnumerable<Product> products = GetProducts();

            Product query = products.First(x => x.Id == productId);

            if (query.Ratings == null) {
                query.Ratings = new int[] { rate };
            } else {
                List<int> ratingsList = query.Ratings.ToList();
                ratingsList.Add(rate);
                query.Ratings = ratingsList.ToArray();
            }

            using (FileStream outputStream = File.OpenWrite(JsonFileName)) {
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions {
                        SkipValidation = true,
                        Indented = true
                    }), 
                    products
                );
            }

        }

    }
}
