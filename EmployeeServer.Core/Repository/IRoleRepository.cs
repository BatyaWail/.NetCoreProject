using EmployeeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Repository
{
    public interface IRoleRepository
    {
        Task<Role> AddAsync(Role role);

        Task<Role> GetByIdAsync(int id);
        Task<Role> GetByNameAsync(string name);

        Task<List<Role>> GetListAsync();

        Task RemoveAsync(int id);

        Task<Role> UpdateAsync(int id, Role role);
    }
}
