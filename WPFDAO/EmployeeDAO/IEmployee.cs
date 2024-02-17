using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFBO.DTO;

namespace WPFDAO.EmployeeDAO
{
    public interface IEmployee
    {
        // ADMIN PAGE METHODS 
        public List<EmployeeDTO> GetAllEmployees();

        public bool UpdateEmployee(EmployeeDTO employeeDTO);

        public bool AddEmployee(EmployeeDTO newEmployee);

        public bool DeleteEmployee(int employeeId);

        //EMPLOYEE PAGE METHOD
        public int GetEmployeeID(string username, string password);

        public EmployeeDTO GetUserInfoById(int employeeId);




        // Clear session
        public void ClearSession();
    }
}
