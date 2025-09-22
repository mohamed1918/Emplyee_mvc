using Emplyee_mvc.DataAccess;
using Emplyee_mvc.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Emplyee_mvc.WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index(string employeeSearchName)
        {
            var query = _context.Employees
                                .Include(e => e.Department)
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(employeeSearchName))
            {
                query = query.Where(e => e.Name.Contains(employeeSearchName));
            }

            return View(query.ToList());
        }

        
        public IActionResult Create()
        {
            new SelectList(ViewBag.Departments.ToList(), "Id", "Name");

            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();

                TempData["Message"] = "Employee created successfully!";
                return RedirectToAction("Index");
            }

            new SelectList(ViewBag.Departments.ToList(), "Id", "Name");
            return View(employee);
        }

        
    }
}
