using Emplyee_mvc.BusinessLogic.Interfaces;
using Emplyee_mvc.DataAccess;
using Emplyee_mvc.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Emplyee_mvc.BusinessLogic.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IEmployeeRepository Employees { get; }
        public IDepartmentRepository Departments { get; }

        public UnitOfWork(ApplicationDbContext context,
                          IEmployeeRepository employeeRepo,
                          IDepartmentRepository departmentRepo)
        {
            _context = context;
            Employees = employeeRepo;
            Departments = departmentRepo;
        }

        public int Complete() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}

