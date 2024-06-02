using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSrever.Data.Repository
{
    public class EmployeeRepository :IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public  async Task<Employee> AddAsync(Employee employee)
        {

            _dataContext.Employees.Add(employee);
            await _dataContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> GetByIdAsync(string id)
        {
            return await _dataContext.Employees.Include(u => u.EmployeeRoles).FirstOrDefaultAsync(x => id == x.Identity);
        }
        
        public  async Task<List<Employee>> GetListAsync()
        {
            return await _dataContext.Employees.Include(e=>e.EmployeeRoles).ToListAsync();
        }

        public async Task RemoveAsync(string id)
        {
            var existingEmployee = _dataContext.Employees.FirstOrDefault(x => id == x.Identity);
            if (existingEmployee == null)
            {
                throw new InvalidOperationException($"Employee with ID {id} not found.");
            }
            existingEmployee.Status = false;
           await _dataContext.SaveChangesAsync();
        }
        public async Task<Employee> UpdateAsync(string id, Employee employee)
        {
            var existingEmployee = _dataContext.Employees.FirstOrDefault(x => id == x.Identity);
            if (existingEmployee == null)
            {
                throw new InvalidOperationException($"Employee with ID {id} not found.");
            }

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.StartDate = employee.StartDate;
            existingEmployee.DateOfBirth = employee.DateOfBirth;
            existingEmployee.MaleOrFmale = employee.MaleOrFmale;
            existingEmployee.EmployeeRoles = employee.EmployeeRoles;
            existingEmployee.Status = true;
            foreach (var item in existingEmployee.EmployeeRoles)
            {
                item.EmployeeId = existingEmployee.Id;
            }

            await _dataContext.SaveChangesAsync();

            return existingEmployee;
        }
    }
}
