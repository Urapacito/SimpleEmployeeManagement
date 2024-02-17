using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO.DTO;
using WPFDAO.RoleDAO;
using WPFRepo.RoleRepo;

namespace WPFService.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo roleRepo = null;

        public RoleService()
        {
            roleRepo = new RoleRepo();
        }

        public List<RoleDTO> GetRoles() => roleRepo.GetRoles();

        public bool UpdateRole(RoleDTO updatedRole) => roleRepo.UpdateRole(updatedRole);

        public bool AddRole(RoleDTO newRole) => roleRepo.AddRole(newRole);

        public bool DeleteRole(int roleId) => roleRepo.DeleteRole(roleId);

    }
}
