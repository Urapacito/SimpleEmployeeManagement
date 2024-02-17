using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO.DTO;
using WPFDAO.EmployeeDAO;
using WPFRepo.EmployeeRepo;

namespace WPFService.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo = null;

        public EmployeeService()
        {
            employeeRepo = new EmployeeRepo();
        }

        public List<EmployeeDTO> GetAllEmployees() => employeeRepo.GetAllEmployees();

        public bool UpdateEmployee(EmployeeDTO employeeDTO) => employeeRepo.UpdateEmployee(employeeDTO);

        public bool AddEmployee(EmployeeDTO newEmployee) => employeeRepo.AddEmployee(newEmployee);

        public bool DeleteEmployee(int employeeId) => employeeRepo.DeleteEmployee(employeeId);


        public EmployeeDTO GetUserInfoById(int employeeId) => employeeRepo.GetUserInfoById(employeeId);

        public int GetEmployeeID(string username, string password) => employeeRepo.GetEmployeeID(username, password);


        public void ClearEmployeeSession() => employeeRepo.ClearEmployeeSession();
    }
}
