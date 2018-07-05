using MvcCoreCRUDApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCRUDApplication.EmployeeRepository
{
    public interface IEmployeeRepositoryDAL
    {
        IEnumerable<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        Employee GetEmployeeData(int? id);

        void DeleteEmployee(int? id);
    }
}
