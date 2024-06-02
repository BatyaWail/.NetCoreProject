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
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> AddRoleAsync(Role role)
        {
            return await _roleRepository.AddAsync(role);
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {

            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<List<Role>> GetRolesListAsync()
        {
            return await _roleRepository.GetListAsync();
        }

        public async Task RemoveRoleAsync(int id)
        {
           await _roleRepository.RemoveAsync(id);
        }

        public async Task<Role> UpdateRoleAsync(int id, Role role)
        {
            return await _roleRepository.UpdateAsync(id, role);
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _roleRepository.GetByNameAsync(name);
        }
    }
}
