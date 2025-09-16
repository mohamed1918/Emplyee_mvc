using Emplyee_mvc.BusinessLogic.Interfaces;
using Emplyee_mvc.DataAccess.Models;
using Emplyee_mvc.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplyee_mvc.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo) => _repo = repo;

        public IEnumerable<Employee> GetAll() => _repo.GetAll();
        public Employee? GetById(int id) => _repo.GetById(id);
        public void Create(Employee employee) => _repo.Add(employee);
        public void Update(Employee employee) => _repo.Update(employee);
        public void Delete(int id)
        {
            var emp = _repo.GetById(id);
            if (emp != null) _repo.Delete(emp);
        }
    }
}
