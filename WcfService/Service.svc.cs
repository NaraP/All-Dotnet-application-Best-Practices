using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Transactions;
using BusinessEntities.Customer;
using BusinessLogicLayer;
using BusinessLogicLayer.CustomerRespository;
using DataAccessLayer;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,ConcurrencyMode = ConcurrencyMode.Multiple,ReleaseServiceInstanceOnTransactionComplete =false)]
    public class Service : IService
    {
        ICustomerRespositoryBLL CustBll = new CustomerRespositoryBLL();

        /// <summary>
        /// DeletCustomerData this method is used to delete the customer record from the database table
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        [OperationBehavior(TransactionScopeRequired = true)]
        public string DeletCustomerData(Customers Customer)
        {
            ServiceExceptions myServiceData = new ServiceExceptions();

            string StrDeleteCustomer = string.Empty;

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    StrDeleteCustomer = CustBll.DeleteCustomerData(Customer);
                    ts.Complete();
                }
                catch (SqlException sqlEx)
                {
                    ts.Dispose();
                    myServiceData.Result = true;
                    myServiceData.ErrorMessage = "Connection can not open this " +
                       "time either connection string is wrong or Sever is down. Try later";
                    myServiceData.ErrorDetails = sqlEx.ToString();
                    throw new FaultException<ServiceExceptions>(myServiceData, sqlEx.ToString());
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                    myServiceData.Result = false;
                    myServiceData.ErrorMessage = "unforeseen error occurred. Please try later.";
                    myServiceData.ErrorDetails = ex.ToString();
                    throw new FaultException<ServiceExceptions>(myServiceData, ex.ToString());
                }
            }
            return StrDeleteCustomer;
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomerData()
        {
            ServiceExceptions myServiceData = new ServiceExceptions();

            DataTable dt = new DataTable();

            try
            {
                dt = CustBll.GetCustomerData();
            }
            catch (SqlException sqlEx)
            {
                myServiceData.Result = true;
                myServiceData.ErrorMessage = "Connection can not open this " +
                   "time either connection string is wrong or Sever is down. Try later";
                myServiceData.ErrorDetails = sqlEx.ToString();
                throw new FaultException<ServiceExceptions>(myServiceData, sqlEx.ToString());
            }
            catch (Exception ex)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "unforeseen error occurred. Please try later.";
                myServiceData.ErrorDetails = ex.ToString();
                throw new FaultException<ServiceExceptions>(myServiceData, ex.ToString());
            }
            return dt;
        }

        /// <summary>
        /// SaveCustomerData this method is used to save the customer data into database
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        [OperationBehavior(TransactionScopeRequired = true)]
        public string SaveCustomerData(Customers Customer)
        {
            ServiceExceptions myServiceData = new ServiceExceptions();

            string StrSaveCustomer = string.Empty;

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    StrSaveCustomer = CustBll.InsertCustomerData(Customer);
                    ts.Complete();
                }
                catch (SqlException sqlEx)
                {
                    ts.Dispose();
                    myServiceData.Result = true;
                    myServiceData.ErrorMessage = "Connection can not open this " +
                       "time either connection string is wrong or Sever is down. Try later";
                    myServiceData.ErrorDetails = sqlEx.ToString();
                    throw new FaultException<ServiceExceptions>(myServiceData, sqlEx.ToString());
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                    myServiceData.Result = false;
                    myServiceData.ErrorMessage = "unforeseen error occurred. Please try later.";
                    myServiceData.ErrorDetails = ex.ToString();
                    throw new FaultException<ServiceExceptions>(myServiceData, ex.ToString());
                }
            }
            return StrSaveCustomer;
        }

        /// <summary>
        /// UpdateCustomerData this method is used to update the customer data
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        [OperationBehavior(TransactionScopeRequired = true)]
        public string UpdateCustomerData(Customers Customer)
        {
            ServiceExceptions myServiceData = new ServiceExceptions();

            string StrUpdateCustomer = string.Empty;
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    StrUpdateCustomer = CustBll.UpdateCustomerData(Customer);
                    ts.Complete();
                }
                catch (SqlException sqlEx)
                {
                    ts.Dispose();
                    myServiceData.Result = true;
                    myServiceData.ErrorMessage = "Connection can not open this " +
                       "time either connection string is wrong or Sever is down. Try later";
                    myServiceData.ErrorDetails = sqlEx.ToString();
                    throw new FaultException<ServiceExceptions>(myServiceData, sqlEx.ToString());
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                    myServiceData.Result = false;
                    myServiceData.ErrorMessage = "unforeseen error occurred. Please try later.";
                    myServiceData.ErrorDetails = ex.ToString();
                    throw new FaultException<ServiceExceptions>(myServiceData, ex.ToString());
                }
            }
            return StrUpdateCustomer;
        }
    }
}
