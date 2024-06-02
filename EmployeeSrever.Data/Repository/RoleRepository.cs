using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSrever.Data.Repository
{
    public class RoleRepository:IRoleRepository
    {
        private readonly DataContext _dataContext;
        public RoleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Role> AddAsync(Role role)
        {
            _dataContext.Roles.Add(role);
           await _dataContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _dataContext.Roles.Include(r => r.EmployeeRoles).FirstAsync(x => x.RoleId == id);
        }
        public async Task<Role> GetByNameAsync(string name)
        {
            return await _dataContext.Roles.Include(r => r.EmployeeRoles).FirstOrDefaultAsync(x => x.RoleName == name);
        }
        public async Task<List<Role>> GetListAsync()
        {
            return await _dataContext.Roles.Include(r=>r.EmployeeRoles).ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _dataContext.Roles.Remove(_dataContext.Roles.ToList().Find(x => x.RoleId == id));
           await _dataContext.SaveChangesAsync();
        }


        public async Task<Role> UpdateAsync(int id, Role role)
        {
            var existingRole = _dataContext.Roles.Find(id);
            if (existingRole == null)
            {
                throw new InvalidOperationException($"Role with ID {id} not found.");
            }

            existingRole.RoleName = role.RoleName;


            await _dataContext.SaveChangesAsync();

            return existingRole;
        }

       
    }
}
