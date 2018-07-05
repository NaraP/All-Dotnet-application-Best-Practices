using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    public class CustomersController : ApiController
    {
        private SampleDBEntities db = new SampleDBEntities();

        // GET: api/Customers - Method is used for the get the Customer details
        [ExceptionLoggerFilter]
        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }

        // GET: api/Customers/5 -
        [ResponseType(typeof(Customer))]
        [ExceptionLoggerFilter]
        public IHttpActionResult GetCustomer(string CustomerID)
        {
            Customer customer = db.Customers.Find(CustomerID);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        [ExceptionLoggerFilter]
        public IHttpActionResult PutCustomer(string CustomerID, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CustomerID != customer.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(CustomerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        [ExceptionLoggerFilter]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerID }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        [ExceptionLoggerFilter]
        public IHttpActionResult DeleteCustomer(string CustomerID)
        {
            Customer customer = db.Customers.Find(CustomerID);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [ExceptionLoggerFilter]
        private bool CustomerExists(string CustomerID)
        {
            return db.Customers.Count(e => e.CustomerID == CustomerID.ToString()) > 0;
        }
    }
}
