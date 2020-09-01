using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCRUD.Models;

namespace WebApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
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

        //GET ALL products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        //GET SPECIFIC product
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            return product;
        }

        //ADD new product
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            products.Add(product);
        }

        //DELETE product
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = products.Where(p => p.Id == id);
            products = products.Except(product).ToList();
        }

        //UPDATE product
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var existingProduct = products.Where(p => p.Id == id);
            products = products.Except(existingProduct).ToList();

            products.Add(product);
        }
    }
}
