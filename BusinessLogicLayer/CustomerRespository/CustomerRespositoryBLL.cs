using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Customer;
using DataAccessLayer.CustomerRespository;
using Utillity.ErrorLogs;

namespace BusinessLogicLayer.CustomerRespository
{
    public class CustomerRespositoryBLL : ICustomerRespositoryBLL
    {
        ICustomerRespositoryDAL CustDal = null;
        IErrorLogger ErrorLog = null;

        public CustomerRespositoryBLL()
        {
            CustDal = new CustomerRespositoryDAL();
            ErrorLog = new ErrorLogger();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objcust"></param>
        /// <returns></returns>
        public string DeleteCustomerData(Customers objcust)
        {
           return CustDal.DeleteCustomerData(objcust);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomerData()
        {
            DataTable dtCust = new DataTable();

            try
            {
                dtCust = CustDal.GetCustomerData();
            }
            catch(Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "Customer Repository Business Logic Layer", "GetCustomerData", "Customer BLL");
            }
            return dtCust;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objcust"></param>
        /// <returns></returns>
        public string InsertCustomerData(Customers objcust)
        {
           return  CustDal.InsertCustomerData(objcust);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public Customers SelectDatabyCustomerID(string CustomerID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objcust"></param>
        /// <returns></returns>
        public string UpdateCustomerData(Customers objcust)
        {
            return CustDal.UpdateCustomerData(objcust);
        }
    }
}
