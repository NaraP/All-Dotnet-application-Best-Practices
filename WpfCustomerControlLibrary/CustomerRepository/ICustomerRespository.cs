using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCustomerControlLibrary.Model;

namespace WpfCustomerControlLibrary.CustomerRepository
{
    public interface ICustomerRespository
    {
        int InsertCustomerData(Customers objcust);
        int UpdateCustomerData(Customers objcust);
        int DeleteCustomerData(Customers objcust);
        List<Customers> GetCustomerData();
        Customers SelectDatabyCustomerID(string CustomerID);
    }
}
