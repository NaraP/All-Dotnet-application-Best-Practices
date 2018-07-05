using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COREWebAPICRUDApplication.CustomerRepository;
using COREWebAPICRUDApplication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace COREWebAPICRUDApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ICustomerRespository CustObj = null;
        public EmployeeController(ICustomerRespository _CustObj)
        {
            CustObj = _CustObj;
        }
        // GET api/values
        [HttpGet]
        [ExceptionLoggerFilter]
        public IEnumerable<Customer> Get()
        {
            return CustObj.GetCustomerData();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [ExceptionLoggerFilter]
        public void Post([FromBody]string value)
        {
            Customer cust = new Customer();
            //Read all save customer data from the form body and assign to customer object
            cust.CustomerID = "";

            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
            int  Result= CustObj.InsertCustomerData(cust);

        }

        // PUT api/values/5
        [HttpPut("{id?}")] //id is the optional
        [ExceptionLoggerFilter]
        public void Put(int id, [FromBody]string value)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
            Customer cust = new Customer();
            //Read all update customer data from the form body and assign to customer object
            cust.CustomerID = "";
            int Result = CustObj.UpdateCustomerData(cust);
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]//id is madatory only int type
        [ExceptionLoggerFilter]
        public void Delete(int id)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
            Customer cust = new Customer();

            int Result = CustObj.DeleteCustomerData(cust);


        }
    }
}
