using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using COREWebAPICRUDApplication.Model;
using Utillity.ErrorLogs;

namespace COREWebAPICRUDApplication.CustomerRepository
{
    public class CustomerRespository : ICustomerRespository
    {
       public readonly IErrorLogger ErrorLog = new ErrorLogger();

        string connectionString = GetConfigFileData.GetConfigurationData();

        public int DeleteCustomerData(Customer objcust)
        {
            int DeleteCustomerData = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteCustomerData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", objcust.CustomerID);
                    con.Open();
                    DeleteCustomerData = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "DeleteCustomerData", "Cusomer Module");
            }
            return DeleteCustomerData;
        }

        public List<Customer> GetCustomerData()
        {
            List<Customer> lstemployee = new List<Customer>();
            Customer customer = null;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SelectCustomers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                         customer = new Customer();
                        customer.CustomerID = Convert.ToString(rdr["CustomerID"]);
                        customer.Name = rdr["Name"].ToString();
                        customer.Address = rdr["Address"].ToString();
                        customer.Mobileno = rdr["Mobileno"].ToString();
                        customer.EmailID = rdr["EmailID"].ToString();
                        lstemployee.Add(customer);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "GetCustomerData", "Cusomer Module");
            }
            return lstemployee;
        }

        public int InsertCustomerData(Customer objcust)
        {
            int SavaCustomerData = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("InsertCustomerDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", objcust.CustomerID);
                    cmd.Parameters.AddWithValue("@Name", objcust.Name);
                    cmd.Parameters.AddWithValue("@Mobileno", objcust.Mobileno);
                    cmd.Parameters.AddWithValue("@Address", objcust.Address);
                    cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);

                    con.Open();
                    SavaCustomerData= cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "InsertCustomerData", "Cusomer Module");
            }
            return SavaCustomerData;
        }

        public Customer SelectDatabyCustomerID(string CustomerID)
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomerData(Customer objcust)
        {
            int UpdateCustomerData = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateCustomerDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", objcust.CustomerID);
                    cmd.Parameters.AddWithValue("@Name", objcust.Name);
                    cmd.Parameters.AddWithValue("@Mobileno", objcust.Mobileno);
                    cmd.Parameters.AddWithValue("@Address", objcust.Address);
                    cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);

                    con.Open();
                    UpdateCustomerData = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "UpdateCustomerData", "Cusomer Module");
            }
            return UpdateCustomerData;
        }
    }
}
