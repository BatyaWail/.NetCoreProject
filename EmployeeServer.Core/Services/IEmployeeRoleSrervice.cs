using EmployeeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Services
{
    public interface IEmployeeRoleSrervice
    {
        Task<EmployeeRole> GetByEmployeeIdAndRoleIdAsync(int employeeId, int roleId);
    }
}
