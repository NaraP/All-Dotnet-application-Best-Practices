using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utillity.ErrorLogs
{
    public interface IErrorLogger
    {
        void ExceptionHandler(Exception ex, string strPolicy, string ModuleName);
        void ExceptionWriteIntoTextFile(Exception ex, string strPolicy, string strQuery, string ModuleName);
    }
}
