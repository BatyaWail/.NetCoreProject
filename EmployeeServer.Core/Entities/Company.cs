using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
