using EmployeeServer.Core.Entities;

namespace EmployeeServer.Api.Model
{
    public class EmployeeRolePostModel
    {
        //public int EmployeeId { get; set; }

        public int RoleId { get; set; }
        public bool IsManagementRole { get; set; }

        // תוספת כלשהי, אם רצוי
        // public DateTime AssignedDate { get; set; }
        public DateTime EntryDate { get; set; }
        //public int CompanyId { get; set; }

    }
}
