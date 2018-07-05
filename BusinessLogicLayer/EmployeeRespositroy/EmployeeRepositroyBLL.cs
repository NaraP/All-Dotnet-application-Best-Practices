using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Employee;
using DataAccessLayer.EmployeeRepository;
using Utillity.ErrorLogs;

namespace BusinessLogicLayer.EmployeeRespositroy
{
    public class EmployeeRepositroyBLL : IEmployeeRepositroyBLL
    {
        IEmployeeRespositoryDAL EmpDal = null;
        IErrorLogger ErrorLog = null;

        public EmployeeRepositroyBLL()
        {
            EmpDal = new EmployeeRespositoryDAL();
            ErrorLog = new ErrorLogger();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetEmployeesData()
        {
           return  EmpDal.GetEmployeesData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Emps"></param>
        /// <returns></returns>
        public int SaveEmployeesBonusData(Empoyees Emps)
        {
           return EmpDal.SaveEmployeesBonusData(Emps);
        }
    }
}
