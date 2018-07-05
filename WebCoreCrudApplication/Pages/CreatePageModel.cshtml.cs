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
    public class CreatePageModelModel : PageModel
    {
        public IEmployeeRepositoryDAL EmpDal = null;

        public CreatePageModelModel(IEmployeeRepositoryDAL _EmpDal)
        {
            EmpDal = _EmpDal;
        }
        [BindProperty]
        public Employees Employee { get; set; }

        //Method to create employee record in database
        public IActionResult OnPostAsync(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            EmpDal.AddEmployee(employees);

            return RedirectToPage("/Index");
        }

    }
}