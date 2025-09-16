using Emplyee_mvc.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplyee_mvc.DataAccess.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
