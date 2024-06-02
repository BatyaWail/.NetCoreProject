using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Entities
{

    public class Employee
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool MaleOrFmale { get; set; }
        public List<EmployeeRole> EmployeeRoles { get; set; } 
        public bool Status { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
