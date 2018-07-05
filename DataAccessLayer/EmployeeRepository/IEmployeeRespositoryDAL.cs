using BusinessEntities.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EmployeeRepository
{
    public interface IEmployeeRespositoryDAL
    {
        DataTable GetEmployeesData();
        int SaveEmployeesBonusData(Empoyees Emps);

    }
}
