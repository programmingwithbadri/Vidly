using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: api/Customers
        //If you don't give HTTP GET, mvc will automatically search for Get Action(method)
        //in the controller to process HTTP GET function
        // [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customers = _context.Customers.ToList();
            if (customers == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customers;
        }

        // GET: api/Customers/1
        public Customer Get(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }

        // POST: api/Customers
        public void Post(Customer Customer)
        {
        }

        // PUT: api/Customers/5
        public void Put(int id, [FromBody]Customer Customer)
        {
        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
        }
    }
}
