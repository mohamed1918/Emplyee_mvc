using Emplyee_mvc.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplyee_mvc.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
