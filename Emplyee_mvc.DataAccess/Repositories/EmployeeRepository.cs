using Emplyee_mvc.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplyee_mvc.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) => _context = context;

        public IEnumerable<Employee> GetAll() => _context.Employees.AsNoTracking().ToList();
        public Employee? GetById(int id) => _context.Employees.Find(id);
        public void Add(Employee employee) { _context.Employees.Add(employee); _context.SaveChanges(); }
        public void Update(Employee employee) { _context.Employees.Update(employee); _context.SaveChanges(); }
        public void Delete(Employee employee) { _context.Employees.Remove(employee); _context.SaveChanges(); }
    }
}
