using Emplyee_mvc.BusinessLogic.Interfaces;
using Emplyee_mvc.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emplyee_mvc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _service;
        public EmployeesController(IEmployeeService service) => _service = service;

        public IActionResult Index() => View(_service.GetAll());
        public IActionResult Details(int id) => View(_service.GetById(id));
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);
            _service.Create(employee);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id) => View(_service.GetById(id));

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);
            _service.Update(employee);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id) => View(_service.GetById(id));

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
