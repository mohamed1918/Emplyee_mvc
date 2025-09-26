using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emplyee_mvc.BusinessLogic.Interfaces;
using Emplyee_mvc.BusinessLogic.Repositories;
using Emplyee_mvc.DataAccess.Repositories;

namespace Emplyee_mvc.BusinessLogic.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        int Complete();
    }
}

