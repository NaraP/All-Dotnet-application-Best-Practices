using MvcCoreCRUDApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Utillity.ErrorLogs;

namespace MvcCoreCRUDApplication.EmployeeRepository
{
    public class EmployeeRepositoryDAL : IEmployeeRepositoryDAL
    {
        public readonly IErrorLogger ErrorLog = new ErrorLogger();

        string connectionString = GetConfigFileData.GetConfigurationData();

        //To View all employees details    
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lstemployee = new List<Employee>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    
                    SqlDataReader rdr =  cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
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
            catch(Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "GetAllEmployees", "Employee Module");
            }
            return lstemployee;
        }
        //To Add new employee record    
        public void AddEmployee(Employee employee)
        {
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
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "AddEmployee", "Employee Module");
            }
        }
        //To Update the records of a particluar employee  
        public void UpdateEmployee(Employee employee)
        {
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
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "UpdateEmployee", "Employee Module");
            }
        }
        //Get the details of a particular employee  
        public Employee GetEmployeeData(int? id)
        {
            Employee employee = new Employee();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr =  cmd.ExecuteReader();
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
            catch(Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "GetEmployeeData", "Employee Module");
            }
            return employee;
        }
        //To Delete the record on a particular employee  
        public void DeleteEmployee(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                ErrorLog.ExceptionHandler(ex, "DeleteEmployee", "Employee Module");
            }
        }
    }
}
