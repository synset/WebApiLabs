using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFromScratch.Models;

namespace WebApiFromScratch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>()
        {
            new Product {
                Id = 1006368,
                Name = "Austin and Barbeque",
                Description = "Thermometer",
                Price = 399
            },

            new Product {
                Id = 1009334,
                Name = "Andersson",
                Description = "Tändare",
                Price = 89
            },

            new Product {
                Id = 1002266,
                Name = "Weber",
                Description = "Oil",
                Price = 99
            }
        };


        [HttpGet] //Get ALL products
        public IEnumerable<Product> Get()
        {
            return products;
        }
    }
}
