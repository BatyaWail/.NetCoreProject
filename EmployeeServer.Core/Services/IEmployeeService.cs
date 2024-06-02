using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Services
{
    public interface IEmployeeService
    {
        Task<Employee> AddEmployeeAsync(Employee employee);

        Task<Employee> GetEmployeeByIdAsync(string id);
        Task<List<Employee>> GetEmployeesListAsync();

        Task RemoveEmployeeAsync(string id);

        Task<Employee> UpdateEmployeeAsync(string id, Employee employee);
    }
}
