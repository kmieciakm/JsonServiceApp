using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JsonTestApp.Models;
using JsonTestApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsonTestApp.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductsController : ControllerBase {
        public JsonService JsonService { get; }

        public ProductsController( JsonService jsonService ) {
            JsonService = jsonService;
        }

        [Route("[controller]")]
        [HttpGet]
        public IEnumerable<Product> Get() {
            return JsonService.GetProducts();
        }
    }
}