using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using EmployeeServer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeServer.Service.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRoleRepository _roleRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IRoleRepository roleRepository)
        {
            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            // Identity validation
            if (!IsValidIdentity(employee.Identity))
            {
                throw new ArgumentException("Invalid identity format. Identity must be 9 digits.");
            }
            // Check if the identity already exists in the database
            var existingEmployee = await _employeeRepository.GetByIdAsync(employee.Identity);
            if (existingEmployee != null)
            {
                throw new ArgumentException("An employee with this identity already exists.");
            }

            // Date of Birth validation (assuming minimum age of 18)
            if (!IsValidDateOfBirth(employee.DateOfBirth))
            {
                throw new ArgumentException("Employee must be at least 18 years old.");
            }

            // Start Date validation
            if (!IsValidStartDate(employee.StartDate))
            {
                throw new ArgumentException("Start date cannot be in the future.");
            }
            if (employee.EmployeeRoles != null && employee.EmployeeRoles.Any())
            {
                foreach (var role in employee.EmployeeRoles)
                {
                    if (!IsValidEntryDate(role.EntryDate, employee.StartDate))
                    {
                        throw new ArgumentException("Entry date for role cannot be before start date.");
                    }
                }
            }
            return await _employeeRepository.AddAsync(employee);
        }
        private bool IsValidIdentity(string identity)
        {
            // Adjust the regex according to your specific identity format
            const string identityRegex = "^\\d{9}$";
            return Regex.IsMatch(identity, identityRegex);
        }

        private bool IsValidDateOfBirth(DateTime dateOfBirth)
        {
            const int minimumAge = 18;
            var currentDate = DateTime.UtcNow;
            var minimumDateOfBirth = currentDate.AddYears(-minimumAge);
            return dateOfBirth <= minimumDateOfBirth;
        }

        private bool IsValidStartDate(DateTime startDate)
        {
            var currentDate = DateTime.UtcNow;
            return startDate <= currentDate;
        }

        private bool IsValidEntryDate(DateTime? entryDate, DateTime startDate)
        {
            return entryDate != null && entryDate >= startDate;
        }
        public async Task<Employee> UpdateEmployeeAsync(string id, Employee employee)
        {
            // Identity validation
            if (!IsValidIdentity(employee.Identity))
            {
                throw new ArgumentException("Invalid identity format. Identity must be 9 digits.");
            }

            // Date of Birth validation (assuming minimum age of 18)
            if (!IsValidDateOfBirth(employee.DateOfBirth))
            {
                throw new ArgumentException("Employee must be at least 18 years old.");
            }

            // Start Date validation
            if (!IsValidStartDate(employee.StartDate))
            {
                throw new ArgumentException("Start date cannot be in the future.");
            }

            // Entry Date validation (assuming Entry Date cannot be before Start Date)
            if (employee.EmployeeRoles != null && employee.EmployeeRoles.Any())
            {
                foreach (var role in employee.EmployeeRoles)
                {
                    if (!IsValidEntryDate(role.EntryDate, employee.StartDate))
                    {
                        throw new ArgumentException("Entry date for role cannot be before start date.");
                    }
                }
            }

            // Role Name duplicates validation (assuming validation happens before adding employee)
            // This logic requires access to existing employee roles in the database
            // Implement logic to check for duplicate role names among existing roles and new roles
            //var existingRole = await _roleRepository.GetListAsync();
            //int[] exisitingRoleId = new int[existingRole.Count];
            //for (int i = 0; i < exisitingRoleId.Length; i++)
            //{
            //    exisitingRoleId[i] = existingRole[i].Id;
            //}
            //var newRoleIds = employee.EmployeeRoles.Select(r => r.RoleId);
            //if (newRoleIds.Intersect(exisitingRoleId).Any())
            //{
            //    throw new ArgumentException("Duplicate role names found. Role names must be unique.");
            //}
            return await _employeeRepository.UpdateAsync(id, employee);
        }
        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }
        public async Task<List<Employee>> GetEmployeesListAsync()
        {
            return await _employeeRepository.GetListAsync();
        }

        public async Task RemoveEmployeeAsync(string id)
        {
           await _employeeRepository.RemoveAsync(id);
        }


    }
}
