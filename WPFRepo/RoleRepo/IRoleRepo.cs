using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO.DTO;

namespace WPFRepo.RoleRepo
{
    public interface IRoleRepo
    {
        public List<RoleDTO> GetRoles();

        public bool UpdateRole(RoleDTO updatedRole);

        public bool AddRole(RoleDTO newRole);

        public bool DeleteRole(int roleId);
    }
}
