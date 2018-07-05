using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessEntities.Customer;
using BusinessLogicLayer;
using DataAccessLayer;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        // TODO: Add your service operations here
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [FaultContract(typeof(ServiceExceptions))]
        string SaveCustomerData(Customers Customer);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptions))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string UpdateCustomerData(Customers Customer);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptions))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string DeletCustomerData(Customers Customer);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptions))]
        DataTable GetCustomerData();
    }
}
