using System;
using System.Collections.Generic;

namespace WPFBO
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!; // Added Username
        public string Password { get; set; } = null!; // Added Password
        public int? RoleId { get; set; }
        public int? DepartmentId { get; set; }
        public int? TeamId { get; set; } // Added TeamID

        public virtual Department? Department { get; set; }
        public virtual Role? Role { get; set; }
        public virtual Teams? Team { get; set; } // Added Team
    }
}
