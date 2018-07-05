using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Customer;
using DataAccessLayer.DBHelper;
using Utillity.ErrorLogs;

namespace DataAccessLayer.CustomerRespository
{
    public class CustomerRespositoryDAL : ICustomerRespositoryDAL
    {
        string SqlConnction = String.Empty;

        IErrorLogger ErrorLog = null;

        /// <summary>
        /// 
        /// </summary>
        public CustomerRespositoryDAL()
        {
            SqlConnction = DBConnection.GetConnection().ToString();
            ErrorLog = new ErrorLogger();
        }

        public string DeleteCustomerData(Customers objcust)
        {
            SqlParameter[] SqlParams = new SqlParameter[1];

            string Result = string.Empty;
            try
            {
                SqlParams[0] = SQLDBHelper.CreateParam("@CustomerID", SqlDbType.VarChar, ParameterDirection.Input, objcust.CustomerID);

                Result = SQLDBHelper.ExecuteNonQuery(SqlConnction, CommandType.StoredProcedure, "DeleteCustomerData", SqlParams).ToString();
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "Customer Repository Data Access", "InsertData", "Customer DAL");
            }
            finally
            {
            }
            return Result;
        }

        /// <summary>
        /// GetCustomerData this method is used get the customer details
        /// </summary>
        /// <returns></returns>
        public DataTable GetCustomerData()
        {
            DataSet CustomerData = new DataSet();

            try
            {
                CustomerData = SQLDBHelper.ExecuteDataset(SqlConnction, CommandType.StoredProcedure, "SelectCustomers");
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "Customer Repository Data Access", "GetCustomerData", "Customer DAL");
            }
            return CustomerData.Tables[0];
        }

        /// <summary>
        /// InsertCustomerData  this method is used to insert the customer data into database
        /// </summary>
        /// <param name="objcust"></param>
        /// <returns></returns>
        public string InsertCustomerData(Customers objcust)
        {
            SqlParameter[] SqlParams = new SqlParameter[5];

            string Result = string.Empty;
            try
            {
                SqlParams[0] = SQLDBHelper.CreateParam("@CustomerID", SqlDbType.VarChar, ParameterDirection.Input, objcust.CustomerID);
                SqlParams[1] = SQLDBHelper.CreateParam("@Name", SqlDbType.VarChar, ParameterDirection.Input, objcust.Name);
                SqlParams[2] = SQLDBHelper.CreateParam("@Mobileno", SqlDbType.VarChar, ParameterDirection.Input, objcust.Mobileno);
                SqlParams[3] = SQLDBHelper.CreateParam("@Address", SqlDbType.VarChar, ParameterDirection.Input, objcust.Address);
                SqlParams[4] = SQLDBHelper.CreateParam("@EmailID", SqlDbType.VarChar, ParameterDirection.Input, objcust.EmailID);

                Result = SQLDBHelper.ExecuteNonQuery(SqlConnction, CommandType.StoredProcedure, "InsertCustomerDetails", SqlParams).ToString();
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "Customer Repository Data Access", "InsertData", "Customer DAL");
            }
            finally
            {

            }
            return Result;
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
        /// UpdateCustomerData this is used to update the customer data in the database
        /// </summary>
        /// <param name="objcust"></param>
        /// <returns></returns>
        public string UpdateCustomerData(Customers objcust)
        {
            SqlParameter[] SqlParams = new SqlParameter[5];

            string Result = string.Empty;
            try
            {
                SqlParams[0] = SQLDBHelper.CreateParam("@CustomerID", SqlDbType.VarChar, ParameterDirection.Input, objcust.CustomerID);
                SqlParams[1] = SQLDBHelper.CreateParam("@Name", SqlDbType.VarChar, ParameterDirection.Input, objcust.Name);
                SqlParams[2] = SQLDBHelper.CreateParam("@Mobileno", SqlDbType.VarChar, ParameterDirection.Input, objcust.Mobileno);
                SqlParams[3] = SQLDBHelper.CreateParam("@Address", SqlDbType.VarChar, ParameterDirection.Input, objcust.Address);
                SqlParams[4] = SQLDBHelper.CreateParam("@EmailID", SqlDbType.VarChar, ParameterDirection.Input, objcust.EmailID);

                Result = SQLDBHelper.ExecuteNonQuery(SqlConnction, CommandType.StoredProcedure, "UpdateCustomerDetails", SqlParams).ToString();
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "Customer Repository Data Access", "UpdateData", "Customer DAL");
            }
            finally
            {
                SqlParams = null;
            }
            return Result;
        }
    }
}
