using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utillity.ErrorLogs;
using WpfCustomerControlLibrary.Model;

namespace WpfCustomerControlLibrary.CustomerRepository
{
    public class CustomerRespository : ICustomerRespository
    {
        public readonly IErrorLogger ErrorLog = new ErrorLogger();

        /// <summary>
        /// 
        /// </summary>
        string connectionString = DBConnection.GetConnection();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objcust"></param>
        /// <returns></returns>
        public int DeleteCustomerData(Customers objcust)
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customers> GetCustomerData()
        {
            List<Customers> lstemployee = new List<Customers>();
            Customers customer = null;

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
                        customer = new Customers();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objcust"></param>
        /// <returns></returns>
        public int InsertCustomerData(Customers objcust)
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
                    SavaCustomerData = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "InsertCustomerData", "Cusomer Module");
            }
            return SavaCustomerData;
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
        public int UpdateCustomerData(Customers objcust)
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
