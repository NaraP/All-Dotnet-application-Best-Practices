using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Utillity.ErrorLogs;

namespace DataAccessLayer.DBHelper
{
    public static class DBConnection
    {
        public static string GetConnection()
        {
            string SqlConn = null;

            IErrorLogger ErrorLog = new ErrorLogger();

            try
            {
                 SqlConn = ConfigurationManager.AppSettings["SqlConn"].ToString();
            }
            catch (Exception ex)
            {
                ErrorLog.ExceptionWriteIntoTextFile(ex, "DB connection Data Access", "GetConnection", "DBCOnnection DAL");
            }
            return SqlConn;
        }

        public static void CloseConnection(SqlConnection SqlConn)
        {
            if (SqlConn.State == ConnectionState.Open)
            {
                SqlConn.Open();
            }
        }
    }
}
