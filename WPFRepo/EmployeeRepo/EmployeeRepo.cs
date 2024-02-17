using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFBO.DTO;
using WPFDAO.EmployeeDAO;

namespace WPFRepo.EmployeeRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private EmployeeDAO employeeDAO = null;

        public EmployeeRepo()
        {
            employeeDAO = new EmployeeDAO();
        }

        public List<EmployeeDTO> GetAllEmployees() => employeeDAO.GetAllEmployees();

        public bool UpdateEmployee(EmployeeDTO employeeDTO) => employeeDAO.UpdateEmployee(employeeDTO);

        public bool AddEmployee(EmployeeDTO newEmployee) => employeeDAO.AddEmployee(newEmployee);

        public bool DeleteEmployee(int employeeId) => employeeDAO.DeleteEmployee(employeeId);


        public EmployeeDTO GetUserInfoById(int employeeId) => employeeDAO.GetUserInfoById(employeeId);

        public int GetEmployeeID(string username, string password) => employeeDAO.GetEmployeeID(username, password);


        public void ClearEmployeeSession() => employeeDAO.ClearEmployeeSession();
    }
}
