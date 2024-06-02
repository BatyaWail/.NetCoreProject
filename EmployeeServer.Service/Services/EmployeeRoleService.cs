using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using EmployeeServer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Service.Services
{
    public class EmployeeRoleService : IEmployeeRoleSrervice
    {
        private readonly IEmployeeRoleRepository _employeeRoleRepository;
        public EmployeeRoleService(IEmployeeRoleRepository employeeRoleRepository)
        {
            _employeeRoleRepository = employeeRoleRepository;
        }
        public async Task<EmployeeRole> GetByEmployeeIdAndRoleIdAsync(int employeeId, int roleId)
        {
            return await _employeeRoleRepository.GetByEmployeeIdAndRoleIdAsync(employeeId, roleId);
        }
    }
}
