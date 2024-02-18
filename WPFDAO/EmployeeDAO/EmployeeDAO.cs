using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBO;
using WPFBO.DTO;

namespace WPFDAO.EmployeeDAO
{
    public class EmployeeDAO
    {
        private IEmployee employee;

        private readonly EmpManagementContext _empManagementContext = null;

        private static EmployeeDAO instance = null;

        public static EmployeeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    return new EmployeeDAO();
                }
                return instance;
            }
        }

        public EmployeeDAO()
        {
            _empManagementContext = new EmpManagementContext();
        }

        // Get all employees
        public List<EmployeeDTO> GetAllEmployees()
        {
            // Read data from sql server
            List<EmployeeDTO> employee = new List<EmployeeDTO>();
            foreach (var item in _empManagementContext.Employees.Include(e => e.Role).Include(e => e.Department))
            {
                EmployeeDTO emp = new EmployeeDTO();
                emp.EmployeeID = item.EmployeeId;
                emp.FirstName = item.FirstName;
                emp.LastName = item.LastName;
                emp.RoleName = item.Role?.RoleName; // Use null conditional operator to avoid NullReferenceException
                emp.DepartmentName = item.Department?.DepartmentName; // Use null conditional operator to avoid NullReferenceException
                emp.Username = item?.Username;
                emp.Password = item?.Password; // Remember to handle this securely
                emp.TeamID = item?.TeamId;
                employee.Add(emp);
            }
            return employee;
        }


        // Update employee
        public bool UpdateEmployee(EmployeeDTO updatedEmployee)
        {
            try
            {
                // Find the employee in the database
                var employee = _empManagementContext.Employees.FirstOrDefault(e => e.EmployeeId == updatedEmployee.EmployeeID);

                if (employee != null)
                {
                    // Update the employee's details
                    employee.FirstName = updatedEmployee.FirstName;
                    employee.LastName = updatedEmployee.LastName;
                    employee.Username = updatedEmployee.Username;
                    employee.Password = updatedEmployee.Password; // Remember to handle this securely

                    // Look up the RoleID and DepartmentID based on the RoleName and DepartmentName
                    var role = _empManagementContext.Roles.FirstOrDefault(r => r.RoleName == updatedEmployee.RoleName);
                    var department = _empManagementContext.Departments.FirstOrDefault(d => d.DepartmentName == updatedEmployee.DepartmentName);

                    if (role != null)
                    {
                        employee.RoleId = role.RoleId;
                    }

                    if (department != null)
                    {
                        employee.DepartmentId = department.DepartmentId;
                    }


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

        // Add Employee
        /*        public bool AddEmployee(EmployeeDTO newEmployee)
                {
                    try
                    {
                        // Convert DTO to BO
                        Employee employee = new Employee
                        {
                            FirstName = newEmployee.FirstName,
                            LastName = newEmployee.LastName,
                            // Look up the RoleID and DepartmentID based on the RoleName and DepartmentName
                            RoleId = _empManagementContext.Roles.FirstOrDefault(r => r.RoleName == newEmployee.RoleName).RoleId,
                            DepartmentId = _empManagementContext.Departments.FirstOrDefault(d => d.DepartmentName == newEmployee.DepartmentName).DepartmentId,
                        };

                        // Add to database and save changes
                        _empManagementContext.Employees.Add(employee);
                        _empManagementContext.SaveChanges();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }*/

        public bool AddEmployee(EmployeeDTO newEmployee)
        {
            try
            {
                // Convert DTO to BO
                Employee employee = new Employee
                {
                    FirstName = newEmployee.FirstName,
                    LastName = newEmployee.LastName,
                    // Look up the RoleID and DepartmentID based on the RoleName and DepartmentName
                    RoleId = _empManagementContext.Roles.FirstOrDefault(r => r.RoleName == newEmployee.RoleName).RoleId,
                    DepartmentId = _empManagementContext.Departments.FirstOrDefault(d => d.DepartmentName == newEmployee.DepartmentName).DepartmentId,
                };

                // Add to database and save changes
                _empManagementContext.Employees.Add(employee);
                _empManagementContext.SaveChanges();

                // Create the default username and password
                employee.Username = $"{employee.FirstName}@{employee.EmployeeId}";
                employee.Password = $"{employee.FirstName}@{employee.EmployeeId}";

                // Save the changes again
                _empManagementContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        // Delete employee
        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                // Find the employee in the database
                var employee = _empManagementContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

                if (employee != null)
                {
                    // Remove from database and save changes
                    _empManagementContext.Employees.Remove(employee);
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
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Get imployeeID
        public int GetEmployeeID(string username, string password)
        {
            var employee = _empManagementContext.Employees.FirstOrDefault(e => e.Username == username && e.Password == password);
            if (employee != null)
            {
                return employee.EmployeeId;
            }
            else
            {
                return -1;
            }
        }

        // Show employee information in employee page
        public EmployeeDTO GetUserInfoById(int employeeId)
        {
            // Find the employee in the database
            var employee = _empManagementContext.Employees
                .Include(e => e.Role)
                .Include(e => e.Department)
                .FirstOrDefault(e => e.EmployeeId == employeeId);

            // Check if the employee exists
            if (employee != null)
            {
                // If the employee exists, convert it to an EmployeeDTO and return it
                EmployeeDTO employeeDTO = new EmployeeDTO
                {
                    EmployeeID = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    RoleName = employee.Role.RoleName,
                    DepartmentName = employee.Department.DepartmentName,
                    Username = employee.Username,
                    Password = employee.Password,
                    TeamID = employee.TeamId
                };

                return employeeDTO;
            }
            else
            {
                // If the employee does not exist, return null
                return null;
            }
        }

        // Clear session
        public void ClearEmployeeSession()
        {
            // If the session data is stored in memory, nullify or reset the variables
            employee = null;

            // If the session data is stored in the database, update the database
            // For example, if you have a 'Session' table in your database:
            /*
            var session = _empManagementContext.Sessions.FirstOrDefault(s => s.EmployeeId == employee.EmployeeId);
            if (session != null)
            {
                session.IsActive = false;
                _empManagementContext.SaveChanges();
            }
            */

            // If you're using an authentication library that provides a method to invalidate the session, call that method
            // For example:
            // FormsAuthentication.SignOut();
        }



    }
}
