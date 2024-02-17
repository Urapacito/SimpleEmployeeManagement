using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFBO.DTO;
using WPFDAO.EmployeeDAO;

namespace WPFDAO.DepartmentDAO
{
    public class DepartmentDAO
    {
        private IDepartment department;

        private readonly EmpManagementContext _empManagementContext = null;

        private static DepartmentDAO instance = null;

        public static DepartmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new DepartmentDAO();
                }
                return instance;
            }
        }

        public DepartmentDAO()
        {
            _empManagementContext = new EmpManagementContext();
        }

        // Get all departments 
        public List<DepartmentDTO> GetAllDepartments()
        {
            List<DepartmentDTO> departments = new List<DepartmentDTO>();
            foreach (var item in _empManagementContext.Departments)
            {
                DepartmentDTO dept = new DepartmentDTO();
                dept.DepartmentID = item.DepartmentId;
                dept.DepartmentName = item.DepartmentName;
                departments.Add(dept);
            }
            return departments;
        }

        // Update department
        public bool UpdateDepartment(DepartmentDTO updatedDepartment)
        {
            try
            {
                // Find the department in the database
                var department = _empManagementContext.Departments.FirstOrDefault(d => d.DepartmentId == updatedDepartment.DepartmentID);

                if (department != null)
                {
                    // Update the department's details
                    department.DepartmentName = updatedDepartment.DepartmentName;

                    // Save the changes
                    _empManagementContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Add department
        public bool AddDepartment(DepartmentDTO newDepartment)
        {
            try
            {
                // Create a new department
                Department department = new Department
                {
                    DepartmentName = newDepartment.DepartmentName
                };

                // Add the new department to the database
                _empManagementContext.Departments.Add(department);
                _empManagementContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Delete department
        public bool DeleteDepartment(int departmentId)
        {
            try
            {
                // Find the department in the database
                var department = _empManagementContext.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);

                if (department != null)
                {
                    // Remove the department from the database
                    _empManagementContext.Departments.Remove(department);
                    _empManagementContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
