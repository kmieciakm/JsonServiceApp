using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonTestApp.Models {
    public class Product {

        [Key]
        [Required]
        public string Id { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public string Location { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Range(1,5)]
        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Product>(this);

    }
}
