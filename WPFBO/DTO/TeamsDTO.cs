using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBO.DTO
{
    public class TeamDTO
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int ManagerID { get; set; }
        public string ManagerName { get; set; }
        public List<EmployeeDTO> TeamMembers { get; set; }
    }
}
