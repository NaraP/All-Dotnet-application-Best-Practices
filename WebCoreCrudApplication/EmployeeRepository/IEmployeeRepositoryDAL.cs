using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreCrudApplication.Model;

namespace WebCoreCrudApplication.EmployeeRepository
{
    public interface IEmployeeRepositoryDAL
    {
        List<Employees> GetAllEmployees();
        int AddEmployee(Employees employee);

        int UpdateEmployee(Employees employee);

       Employees GetEmployeeData(int? id);

        int DeleteEmployee(int? id);
    }
}
