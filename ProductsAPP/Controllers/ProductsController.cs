using ProductsAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsAPP.Controllers
{
    public class ProductsController : ApiController
    {
        static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };
        /// <summary>
        /// 取得所有產品
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        /// <summary>
        /// 取得產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns></returns>
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        /// <summary>
        /// 建立新產品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IHttpActionResult PostProduct(Product product)
        {
            products.Add(product);
            return Created(Url.Link("DefaultApi", new { id = product.Id}), product);
        }
    }
}
