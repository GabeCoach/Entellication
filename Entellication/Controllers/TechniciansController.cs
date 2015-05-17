using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entellication.Models;

namespace Entellication.Controllers
{
    public class TechniciansController : ApiController
    {
        EntellihelpEntities db = new EntellihelpEntities();

        // GET api/technicians
        public IEnumerable<Technician> Get()
        {
            var query = (
                from a in db.Technicians
                select a
                );

                return query;
        }

        // GET api/technicians/5
        public IEnumerable<Technician> Get(int id)
        {
            var query = (
                from a in db.Technicians
                where a.TechnicianID == id
                select a
                );

                return query;
        }

        // POST api/technicians
        public void Post(Technician technician)
        {
            var tech = new Technician();
            tech.FirstName = technician.FirstName;
            tech.LastName = technician.LastName;
            tech.Status = technician.Status;
            tech.Email = technician.Email;
            tech.UserName = technician.UserName;
            tech.Password = technician.Password;

            db.Technicians.Add(tech);
            db.SaveChanges();
        }

        // PUT api/technicians/5
        public void Put(int id, Technician technician)
        {
            using (var context = new EntellihelpEntities())
            {
                var tech = (
                   from a in db.Technicians
                   where a.TechnicianID == id
                   select a
               ).Single();

                tech.FirstName = technician.FirstName;
                tech.LastName = technician.LastName;
                tech.Status = technician.Status;
                tech.Email = technician.Email;
                tech.UserName = technician.UserName;
                tech.Password = technician.Password;

                context.SaveChanges();
            }

            
           
           
        }

        // DELETE api/technicians/5
        public void Delete(int id)
        {
            Technician technician = db.Technicians.Find(id);
            db.Technicians.Remove(technician);
            db.SaveChanges();
        }
    }
}
