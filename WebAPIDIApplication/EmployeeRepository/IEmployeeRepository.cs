using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIDIApplication.Models;

namespace WebAPIDIApplication.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployeeData();
        int InsertEmployeesData(Employee Employees);
        int UpdateEmployeesData(Employee Employees);
        int DeleteEmployeesData(Employee Employees);
    }
}