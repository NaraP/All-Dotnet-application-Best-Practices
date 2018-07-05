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
    public class EditEmployeeModel : PageModel
    {
        public IEmployeeRepositoryDAL EmpDal = null;

        public EditEmployeeModel(IEmployeeRepositoryDAL _EmpDal)
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
            Employee = EmpDal.GetEmployeeData(id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
        //Method to save the data back to database
        public IActionResult OnPostAsync(Employees employee)
        {
            try
            {
                //Updating modified Employee details to database 
                EmpDal.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Redirecting back to Index page after successfull save
            return RedirectToPage("./Index");

        }
    }
}