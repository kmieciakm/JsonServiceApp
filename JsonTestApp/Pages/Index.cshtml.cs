using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonTestApp.Services;
using JsonTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JsonTestApp.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        private JsonService _jsonService;
        public IEnumerable<Product> Products { get; private set; }
        public List<Product> ProductsList { get { return Products.ToList(); } }
        public string AppName { get { return _jsonService.ApplicationName; } }

        public IndexModel( ILogger<IndexModel> logger, JsonService jsonService ) {
            _logger = logger;
            _jsonService = jsonService;
        }

        public void OnGet() {
            Products = _jsonService.GetProducts();
        }
    }
}
