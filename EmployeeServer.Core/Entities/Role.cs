using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Entities
{

    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<EmployeeRole> EmployeeRoles { get; set; }
    }
}
