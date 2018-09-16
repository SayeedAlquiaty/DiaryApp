using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class SellersController : ApiController
    {
        Seller[] sellers = new Seller[] 
        { 
            new Seller { Id = 1, Name = "Seller1", ProductId = 1, Quantity = 1 }, 
            new Seller { Id = 2, Name = "Seller2", ProductId = 2, Quantity = 3 }, 
            new Seller { Id = 3, Name = "Seller3", ProductId = 3, Quantity = 2 } 
        };
        public IEnumerable<Seller> GetAllProducts()
        {
            return sellers;
        }
        public IHttpActionResult GetProduct(int id)
        {
            var seller = sellers.FirstOrDefault((p) => p.Id == id);
            if (seller == null)
            {
                return NotFound();
            }
            return Ok(seller);
        }
    }
}
