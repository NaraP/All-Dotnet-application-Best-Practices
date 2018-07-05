using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Employee;
using DataAccessLayer.DBHelper;
using Utillity.ErrorLogs;

namespace DataAccessLayer.EmployeeRepository
{
    public class EmployeeRespositoryDAL : IEmployeeRespositoryDAL
    {
        string SqlConnction = String.Empty;

        IErrorLogger ErrorLog = null;

        /// <summary>
        /// 
        /// </summary>
        public EmployeeRespositoryDAL()
        {
            SqlConnction = DBConnection.GetConnection().ToString();
            ErrorLog = new ErrorLogger();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetEmployeesData()
        {
             DataSet CustomerData = new DataSet();

            try
            {
                CustomerData = SQLDBHelper.ExecuteDataset(SqlConnction, CommandType.StoredProcedure, "SelectCustomers");
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "Employees Repository Data Access", "GetEmployeesData", "Employees DAL");
            }
            return CustomerData.Tables[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Emps"></param>
        /// <returns></returns>
        public int SaveEmployeesBonusData(Empoyees Emps)
        {
            SqlParameter[] SqlParams = new SqlParameter[6];

            int Result = 0;

            try
            {
                SqlParams[0] = SQLDBHelper.CreateParam("@Empno", SqlDbType.Int, ParameterDirection.Input, Emps.EmpID);
                SqlParams[1] = SQLDBHelper.CreateParam("@EmpName", SqlDbType.VarChar, ParameterDirection.Input, Emps.EMPNAME);
                SqlParams[2] = SQLDBHelper.CreateParam("@Designation", SqlDbType.VarChar, ParameterDirection.Input, Emps.Designation);
                SqlParams[3] = SQLDBHelper.CreateParam("@YEAR", SqlDbType.VarChar, ParameterDirection.Input, Emps.Year);
                SqlParams[4] = SQLDBHelper.CreateParam("@Salary", SqlDbType.Int, ParameterDirection.Input, Emps.Salary);
                SqlParams[5] = SQLDBHelper.CreateParam("@BonusVal", SqlDbType.VarChar, ParameterDirection.Input, Emps.BonusValue);
                SqlParams[6] = SQLDBHelper.CreateParam("@BonusType", SqlDbType.VarChar, ParameterDirection.Input, Emps.BonusType);
                SqlParams[7] = SQLDBHelper.CreateParam("@AmountValues", SqlDbType.Int, ParameterDirection.Input, Emps.Amount);

                Result = SQLDBHelper.ExecuteNonQuery(SqlConnction, CommandType.StoredProcedure, "InsertEmployeeBonusData", SqlParams);
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "Employee Repository Data Access", "SaveEmployeesBonusData", "Employee DAL");
            }
            finally
            {
            }
            return Result;
        }

    }
}
