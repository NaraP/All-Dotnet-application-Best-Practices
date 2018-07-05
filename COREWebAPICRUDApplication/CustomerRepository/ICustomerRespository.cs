using COREWebAPICRUDApplication.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace COREWebAPICRUDApplication.CustomerRepository
{
    public interface ICustomerRespository
    {
        int InsertCustomerData(Customer objcust);
        int UpdateCustomerData(Customer objcust);
        int DeleteCustomerData(Customer objcust);
        List<Customer> GetCustomerData();
        Customer SelectDatabyCustomerID(string CustomerID);
    }
}
