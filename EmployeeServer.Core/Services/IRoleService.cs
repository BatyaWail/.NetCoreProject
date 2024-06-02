using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Services
{
    public interface IRoleService
    {
        Task<Role> AddRoleAsync(Role role);

        Task<Role> GetRoleByIdAsync(int id);
        Task<Role> GetRoleByNameAsync(string name);


        Task<List<Role>> GetRolesListAsync();

        Task RemoveRoleAsync(int id);

        Task<Role> UpdateRoleAsync(int id, Role role);
    }
}
