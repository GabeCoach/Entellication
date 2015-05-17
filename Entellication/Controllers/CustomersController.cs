using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entellication.Models;

namespace Entellication.Controllers
{
    public class CustomersController : ApiController
    {
        EntellihelpEntities db = new EntellihelpEntities();
        // GET api/customers
        public IEnumerable<Customer> Get()
        {
            var query = (
              from a in db.Customers
              select a
              );


            return query;
        }

        // GET api/customers/5
        public IEnumerable<Customer> Get(int id)
        {

            var query = (
                from a in db.Customers
                where a.CustomerID == id
                select a
                );

            return query; 
        }

        // POST api/customers
        public void Post(Customer cust)
        {
            var customer = new Customer();
            customer.FirstName = cust.FirstName;
            customer.LastName = cust.LastName;
            customer.CustomerStatus = cust.CustomerStatus;
            customer.Phone = cust.Phone;
            customer.E_Mail = cust.E_Mail;
            customer.Location = cust.Location;
            customer.UserName = cust.UserName;
            customer.Password = cust.Password;

            db.Customers.Add(customer);
            db.SaveChanges();

            if (cust == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // PUT api/customers/5
        public void Put(int id, Customer cust)
        {
            using (var context = new EntellihelpEntities())
            {
                var customer = (
                    from a in db.Customers
                    where a.CustomerID == id
                    select a
                ).Single();

                customer.FirstName = cust.FirstName;
                customer.LastName = cust.LastName;
                customer.CustomerStatus = cust.CustomerStatus;
                customer.E_Mail = cust.E_Mail;
                customer.Phone = cust.Phone;
                customer.Location = cust.Location;
                customer.UserName = cust.UserName;
                customer.Password = cust.Password;
                
                context.SaveChanges();
            }


        }

        // DELETE api/customers/5
        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            
        }
    }
}
