using EmployeeServer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSrever.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=employeeDb");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRole>().HasKey(em => new { em.EmployeeId, em.RoleId });

            // Seed data for Companies
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "company1", Password = "123456" },
                new Company { Id = 2, Name = "company2", Password = "123456" },
                new Company { Id = 3, Name = "company3", Password = "123456" }
            );

            // Seed data for Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Developer" },
                new Role { RoleId = 2, RoleName = "Designer" },
                new Role { RoleId = 3, RoleName = "Manager" },
                new Role { RoleId = 4, RoleName = "Accountant" }
            );

            // Generate random Jewish names for employees (in English)
            var random = new Random();
            var jewishFirstNamesMale = new List<string> { "David", "Abraham", "Moses", "Joseph", "Aaron", "Isaac", "Jacob", "Samuel", "Solomon", "Elijah","Daniel" };
            var jewishFirstNamesFmale = new List<string> { "Zipora", "Rebecca", "Leah", "Sarah", "Miriam", "Esther", "Batya", "Shoshana", "Ruth", "Rachel", "Hannah" };
            var jewishLastNames = new List<string> { "Cohen", "Levi", "Goldberg", "Stein", "Katz", "Rosenb0erg", "Segal", "Weiss", "Adler", "Friedman", "Shapiro", "Gross", "Geller", "Stern", "Blum", "Zimmerman", "Sandler", "Schwartz", "Gordon", "Klein" };

            // Seed data for Employees
            var employees = new List<Employee>();
            //add male employees
            for (int i = 0; i < 15; i++)
            {
                var firstName = jewishFirstNamesMale[random.Next(jewishFirstNamesMale.Count)];
                var lastName = jewishLastNames[random.Next(jewishLastNames.Count)];
                var identity = (i + 1).ToString().PadLeft(9, '0'); // Assuming sequential IDs as identity
                var startDate = DateTime.Now.AddMonths(-random.Next(1, 12)); // Random start date within the past year
                var dateOfBirth = DateTime.Now.AddYears(-random.Next(18, 60)); // Random date of birth between 18 and 60 years ago
                var companyId = random.Next(1, 4); // Random company ID
                var employee = new Employee { Id = i + 1, Identity = identity, FirstName = firstName, LastName = lastName, StartDate = startDate, DateOfBirth = dateOfBirth, MaleOrFmale =true, Status = true, CompanyId = companyId };
                employees.Add(employee);
            }
            //add fmale employees
            for (int i = 0; i < 15; i++)
            {
                var firstName = jewishFirstNamesFmale[random.Next(jewishFirstNamesFmale.Count)];
                var lastName = jewishLastNames[random.Next(jewishLastNames.Count)];
                var identity = (i + 16).ToString().PadLeft(9, '0'); // Assuming sequential IDs as identity
                var startDate = DateTime.Now.AddMonths(-random.Next(1, 12)); // Random start date within the past year
                var dateOfBirth = DateTime.Now.AddYears(-random.Next(18, 60)); // Random date of birth between 18 and 60 years ago
                var companyId = random.Next(1, 4); // Random company ID
                var employee = new Employee { Id = i + 16, Identity = identity, FirstName = firstName, LastName = lastName, StartDate = startDate, DateOfBirth = dateOfBirth, MaleOrFmale = false, Status = true, CompanyId = companyId };
                employees.Add(employee);
            }

            modelBuilder.Entity<Employee>().HasData(employees);

            // Seed data for EmployeeRoles
            var employeeRoles = new List<EmployeeRole>();
            foreach (var employee in employees)
            {
                var rolesCount = random.Next(2, 4); // Assign between 2 to 3 roles to each employee
                var selectedRoles = new List<int>();
                while (selectedRoles.Count < rolesCount)
                {
                    var roleId = random.Next(1, 5); // Randomly select a role
                    if (!selectedRoles.Contains(roleId))
                    {
                        selectedRoles.Add(roleId);
                    }
                }
                foreach (var roleId in selectedRoles)
                {
                    employeeRoles.Add(new EmployeeRole { EmployeeId = employee.Id, RoleId = roleId, IsManagementRole = random.Next(2) == 0, EntryDate = employee.StartDate });
                }
            }
            modelBuilder.Entity<EmployeeRole>().HasData(employeeRoles);
        }

    }
}