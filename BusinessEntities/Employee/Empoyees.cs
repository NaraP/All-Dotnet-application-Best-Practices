using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Employee
{
   public class Empoyees
    {
        public int EmpID { get; set; }
        public string EMPNAME { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
        public string BonusType { get; set; }
        public int BonusValue { get; set; }
        public int Amount { get; set; }
        public string Year { get; set; }

    }
}
