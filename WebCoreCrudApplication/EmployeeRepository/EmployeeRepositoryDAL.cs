using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Utillity.ErrorLogs;
using WebCoreCrudApplication.Model;

namespace WebCoreCrudApplication.EmployeeRepository
{
    public class EmployeeRepositoryDAL : IEmployeeRepositoryDAL
    {
        public readonly IErrorLogger ErrorLog = new ErrorLogger();

        string connectionString = GetConfigFileData.GetConfigurationData();

        //To View all employees details    
        public List<Employees> GetAllEmployees()
        {
            List<Employees> lstemployee = new List<Employees>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Employees employee = new Employees();
                        employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.City = rdr["City"].ToString();
                        lstemployee.Add(employee);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "GetAllEmployees", "Employee Module");
            }
            return lstemployee;
        }
        //To Add new employee record    
        public int AddEmployee(Employees employee)
        {
            int SaveData = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    con.Open();
                    SaveData= cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "AddEmployee", "Employee Module");
            }
            return SaveData;

        }
        //To Update the records of a particluar employee  
        public int UpdateEmployee(Employees employee)
        {
            int updateData = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", employee.ID);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    con.Open();
                    updateData= cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "UpdateEmployee", "Employee Module");
            }
            return updateData;
        }
        //Get the details of a particular employee  
        public Employees GetEmployeeData(int? id)
        {
            Employees employee = new Employees();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.City = rdr["City"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "GetEmployeeData", "Employee Module");
            }
            return employee;
        }
        //To Delete the record on a particular employee  
        public int DeleteEmployee(int? id)
        {
            int DeleteData = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", id);
                    con.Open();
                    DeleteData=cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "DeleteEmployee", "Employee Module");
            }
            return DeleteData;
        }
    }
}
