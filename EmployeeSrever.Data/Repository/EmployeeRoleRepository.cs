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
    public class EmployeeRoleRepository:IEmployeeRoleRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRoleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<EmployeeRole> GetByEmployeeIdAndRoleIdAsync(int employeeId,int roleId)
        {
            var x= await _dataContext.EmployeeRoles.FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.RoleId == roleId);
            return x;
        }
    }
}
