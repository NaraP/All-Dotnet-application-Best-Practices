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
    public class DeletePageModel : PageModel
    {
        public IEmployeeRepositoryDAL EmpDal = null;

        public DeletePageModel(IEmployeeRepositoryDAL _EmpDal)
        {
            EmpDal = _EmpDal;
        }

        [BindProperty]
        public Employees Employee { get; set; }

        //Method to retreive the selected record details
        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Get the value from database based on ID
            Employee =  EmpDal.GetEmployeeData(id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Method to Delete record from database
        public IActionResult OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Delete Employee details to database 

            if (Employee != null)
            {
                Employee =  EmpDal.GetEmployeeData(id);
            }
            //Redirecting back to Index page after successfull Delete operation
            return RedirectToPage("/Index");
        }
    }
}