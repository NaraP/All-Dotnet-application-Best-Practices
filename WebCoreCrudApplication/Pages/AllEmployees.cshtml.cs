using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebCoreCrudApplication.EmployeeRepository;
using WebCoreCrudApplication.Model;

namespace WebCoreCrudApplication.Pages
{
    public class AllEmployeesModel : PageModel
    {
        public IEmployeeRepositoryDAL EmpDal = null;

        //http://www.mukeshkumar.net/articles/aspnet/crud-operation-in-aasp-net-gridview-using-single-stored-procedure
        //    https://www.c-sharpcorner.com/UploadFile/092589/working-with-dropdownlist-slectedindexchanged-event/
        //    http://www.dofactory.com/net/design-patterns
        public AllEmployeesModel(IEmployeeRepositoryDAL _EmpDal)
        {
            EmpDal = _EmpDal;
        }

        public List<Employees> EmployeesList { get; set; }

        public void OnGet()
        {
            var data = EmpDal.GetAllEmployees();

            EmployeesList = data;
        }
    }
}