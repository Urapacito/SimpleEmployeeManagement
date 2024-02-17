using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO.DTO;

namespace WPFDAO.RoleDAO
{
    public interface IRole
    {
        public List<RoleDTO> GetRoles();

        public bool UpdateRole(RoleDTO updatedRole);

        public bool AddRole(RoleDTO newRole);

        public bool DeleteRole(int roleId);
    }
}
