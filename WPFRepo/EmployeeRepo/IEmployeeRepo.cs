using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFBO.DTO;

namespace WPFRepo.EmployeeRepo
{
    public interface IEmployeeRepo
    {
        public List<EmployeeDTO> GetAllEmployees();

        public bool UpdateEmployee(EmployeeDTO employeeDTO);

        public bool AddEmployee(EmployeeDTO newEmployee);

        public bool DeleteEmployee(int employeeId);


        public EmployeeDTO GetUserInfoById(int employeeId);

        public int GetEmployeeID(string username, string password);


        public void ClearEmployeeSession();
    }
}
