using EmployeeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddAsync(Employee employee);

        Task<Employee> GetByIdAsync(string id);
        Task<List<Employee>> GetListAsync();

        Task RemoveAsync(string id);

        Task<Employee> UpdateAsync(string id, Employee employee);
    }
}
