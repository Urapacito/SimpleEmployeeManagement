using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO.DTO;
using WPFDAO.DepartmentDAO;
using WPFRepo.DepartmentRepo;

namespace WPFService.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private DepartmentRepo departmentRepo = null;

        public DepartmentService()
        {
            departmentRepo = new DepartmentRepo();
        }

        public List<DepartmentDTO> GetAllDepartments() => departmentRepo.GetAllDepartments();

        public bool UpdateDepartment(DepartmentDTO updatedDepartment) => departmentRepo.UpdateDepartment(updatedDepartment);

        public bool AddDepartment(DepartmentDTO newDepartment) => departmentRepo.AddDepartment(newDepartment);

        public bool DeleteDepartment(int departmentId) => departmentRepo.DeleteDepartment(departmentId);
    }
}
