using System;
using System.Collections.Generic;

namespace WPFBO
{
    public partial class Teams
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string TeamName { get; set; } // Added TeamName

        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
