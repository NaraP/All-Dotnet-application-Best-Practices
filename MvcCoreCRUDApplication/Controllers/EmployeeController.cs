using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCRUDApplication.EmployeeRepository;
using MvcCoreCRUDApplication.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcCoreCRUDApplication.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IEmployeeRepositoryDAL EmployeeDAL = null;

        /// <summary>
        /// Here impliments constiructor dependency injection
        /// </summary>
        /// <param name="_EmployeeDAL"></param>
        public EmployeeController(IEmployeeRepositoryDAL _EmployeeDAL)
        {
            EmployeeDAL = _EmployeeDAL;
        }

        // GET: EuropeanAirports
        [ExceptionLoggerFilter]
        public IActionResult Index()
        {
            var EmployeeData = EmployeeDAL.GetAllEmployees();
            return View(EmployeeData);
        }

        // GET: EuropeanAirports/Details/5
        public IActionResult Details(int id)
        {
            var EmployeeData = EmployeeDAL.GetEmployeeData(id);
            return View(EmployeeData);
        }

        // GET: EuropeanAirports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EuropeanAirports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExceptionLoggerFilter]
        public IActionResult Create(Employee Emp, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                EmployeeDAL.AddEmployee(Emp);
               return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EuropeanAirports/Edit/5
        [ExceptionLoggerFilter]
        public IActionResult Edit(int id)
        {
            var EmployeeData = EmployeeDAL.GetEmployeeData(id);

            return View(EmployeeData);
        }

        // POST: EuropeanAirports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExceptionLoggerFilter]
        public IActionResult Edit(int id, IFormCollection collection,Employee emp)
        {
            try
            {
                // TODO: Add update logic here
                EmployeeDAL.UpdateEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: EuropeanAirports/Delete/5
        [ValidateAntiForgeryToken]
        [ExceptionLoggerFilter]
        public IActionResult Delete(int id)
        {
            var EmployeeData = EmployeeDAL.GetEmployeeData(id);
            return View(EmployeeData);
        }

        // POST: EuropeanAirports/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExceptionLoggerFilter]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                 EmployeeDAL.DeleteEmployee(id);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
