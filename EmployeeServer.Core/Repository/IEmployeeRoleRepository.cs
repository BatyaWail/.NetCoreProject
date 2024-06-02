using EmployeeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Repository
{
    public interface IEmployeeRoleRepository
    {
        Task<EmployeeRole> GetByEmployeeIdAndRoleIdAsync(int employeeId, int roleId);
    }
}
