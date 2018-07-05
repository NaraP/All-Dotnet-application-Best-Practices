using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utillity.ErrorLogs;
using WebAPIDIApplication.Models;

namespace WebAPIDIApplication.EmployeeRepository
{
    public class EmployeesRepository : IEmployeeRepository
    {
        IErrorLogger ErrorLog = null;

        public EmployeesRepository(IErrorLogger _ErrorLog)
        {
            ErrorLog = _ErrorLog;
        }

        public int DeleteEmployeesData(Employee Employees)
        {
            int DeleteResult = 0;

            try
            {
                using (SampleDBEntities db = new SampleDBEntities())
                {
                    Employee Emps = db.Employees.Where(emp => emp.Id == Employees.Id).FirstOrDefault();
                    db.Employees.Remove(Emps);
                    DeleteResult = db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "Employees Repository Data Access", "DeleteEmployeesData", "Employees DAL");
            }

            return DeleteResult;
        }

        public List<Employee> GetEmployeeData()
        {
            List<Employee> GetListEmployees = null;

            try
            {
                using (SampleDBEntities db = new SampleDBEntities())
                {
                    GetListEmployees = new List<Employee>();

                    var Result = from emp in db.Employees select emp;

                    GetListEmployees = Result.ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "Employees Repository Data Access", "GetEmployeeData", "Employees DAL");
            }

            return GetListEmployees;
        }

        public int InsertEmployeesData(Employee Employees)
        {
            int SaveResult = 0;

            try
            {
                using (SampleDBEntities db = new SampleDBEntities())
                {
                    db.Employees.Add(Employees);
                    SaveResult = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "Employees Repository Data Access", "InsertEmployeesData", "Employees DAL");
            }

            return SaveResult;
        }

        public int UpdateEmployeesData(Employee Employees)
        {
            int UpdateResult = 0;

            try
            {
                using (SampleDBEntities db = new SampleDBEntities())
                {
                    db.Employees.Add(Employees);
                    UpdateResult = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "Employees Repository Data Access", "UpdateEmployeesData", "Employees DAL");
            }

            return UpdateResult;
        }
    }
}