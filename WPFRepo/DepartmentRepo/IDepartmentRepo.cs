using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO.DTO;
using WPFDAO.DepartmentDAO;

namespace WPFRepo.DepartmentRepo
{
    public interface IDepartmentRepo
    {
        public List<DepartmentDTO> GetAllDepartments();

        public bool UpdateDepartment(DepartmentDTO updatedDepartment);

        public bool AddDepartment(DepartmentDTO newDepartment);

        public bool DeleteDepartment(int departmentId);
    }
}
