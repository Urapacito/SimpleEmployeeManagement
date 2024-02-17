using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBO.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? TeamID { get; set; }
    }
}
