using Emplyee_mvc.BusinessLogic.Interfaces;
using Emplyee_mvc.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


public class EmployeesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _environment;

    public EmployeesController(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
    {
        _unitOfWork = unitOfWork;
        _environment = environment;
    }

    [HttpPost]
    public IActionResult Create(Employee employee, IFormFile photo)
    {
        if (ModelState.IsValid)
        {
            if (photo != null && photo.Length > 0)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                Directory.CreateDirectory(uploads); 

                var fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }

                employee.PhotoPath = "/uploads/" + fileName;
            }

            _unitOfWork.Employees.Add(employee);
            _unitOfWork.Complete();
            TempData["Message"] = "Employee created with photo!";
            return RedirectToAction("Index");
        }

        return View(employee);
    }
}

