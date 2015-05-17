using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entellication.Models;
namespace Entellication.Controllers
{
    public class Products2Controller : ApiController
    {
        EntellihelpEntities db = new EntellihelpEntities();

        // GET api/products2
        public IEnumerable<Product> Get()
        {
            
            var query = (
                from a in db.Products
                select a
                );


            return query;
        }

        // GET api/products2/5
        public IEnumerable<Product> Get(int id)
        {
            var query = (
                from a in db.Products
                where a.ProductID == id
                select a
                );
           
            return query; 
        }

        // POST api/products2
        public void Post(Product product)
        {
            var newProduct = new Product();
            newProduct.ProductName = product.ProductName;
            newProduct.ProductType = product.ProductType; 

            db.Products.Add(newProduct);
            db.SaveChanges();

        }

        // PUT api/products2/5
        public void Put(int id, Product product)
        {
            using (var context = new EntellihelpEntities())
            {
                var newproducts = (
                    from a in db.Products
                    where a.ProductID == id
                    select a
                ).Single();

                newproducts.ProductName = product.ProductName;
                newproducts.ProductType = product.ProductType;

                context.SaveChanges();
            }
        }

        // DELETE api/products2/5
        public void Delete(int id)
        {
        }

        [Route("api/products2/GetByName/{name}")]
        [HttpGet]
        public IEnumerable<Product> GetByName(string name)
        {
            var query = (
                from n in db.Products
                where n.ProductName == name
                select n
                );

            return query;
        }

        [Route("api/products2/GetByType/{type}")]
        [HttpGet]
        public IEnumerable<Product> GetByType(string type)
        {
            var query = (
                from t in db.Products
                where t.ProductType == type
                select t
                );

            return query;
        }

    }
}
