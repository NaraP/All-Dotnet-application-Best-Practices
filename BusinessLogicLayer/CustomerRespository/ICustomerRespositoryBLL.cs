using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.CustomerRespository
{
    public interface ICustomerRespositoryBLL
    {
        string InsertCustomerData(BusinessEntities.Customer.Customers objcust);
        string UpdateCustomerData(BusinessEntities.Customer.Customers objcust);
        string DeleteCustomerData(BusinessEntities.Customer.Customers objcust);
        DataTable GetCustomerData();
        BusinessEntities.Customer.Customers SelectDatabyCustomerID(string CustomerID);
    }
}
