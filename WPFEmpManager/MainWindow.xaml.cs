using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFBO;
using WPFBO.DTO;
using WPFDAO;
using WPFService.EmployeeService;
using WPFService.DepartmentService;
using WPFService.RoleService;

namespace WPFEmpManager
{

    public partial class MainWindow : Window
    {

        private readonly IEmployeeService employeeService = null;

        private readonly IDepartmentService departmentService = null;

        private readonly IRoleService roleService = null;

        public event EventHandler LogoutRequested;

        public MainWindow()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            departmentService = new DepartmentService();
            roleService = new RoleService();

            // DATA GRID VIEW
            dataGridEmployees.ItemsSource = employeeService.GetAllEmployees();
            dataGridDepartments.ItemsSource = departmentService.GetAllDepartments();
            dataGridRoles.ItemsSource = roleService.GetRoles();

            //COMBOBOX, get value only, not whole object
            cbRole.ItemsSource = roleService.GetRoles();
            cbDepartment.ItemsSource = departmentService.GetAllDepartments();
        }

        // ALL DATA GRID VIEW

        private void dataGridEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridEmployees.SelectedItem is EmployeeDTO selectedEmployee)
            {
                txtFirstName.Text = selectedEmployee.FirstName;
                txtLastName.Text = selectedEmployee.LastName;

                // Assuming cbRole and cbDepartment are your ComboBoxes and their items are of type RoleDTO and DepartmentDTO
                foreach (RoleDTO role in cbRole.Items)
                {
                    if (role.RoleName == selectedEmployee.RoleName)
                    {
                        cbRole.SelectedItem = role;
                        break;
                    }
                }

                foreach (DepartmentDTO department in cbDepartment.Items)
                {
                    if (department.DepartmentName == selectedEmployee.DepartmentName)
                    {
                        cbDepartment.SelectedItem = department;
                        break;
                    }
                }
            }
        }

        private void dataGridDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridDepartments.SelectedItem is DepartmentDTO selectedDepartment)
            {
                txtDepartmentName.Text = selectedDepartment.DepartmentName;
            }
        }

        private void dataGridRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridRoles.SelectedItem is RoleDTO selectedRole)
            {
                txtRoleName.Text = selectedRole.RoleName;
            }
        }

        // EMPLOYEE BTN

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to add?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // Create a new EmployeeDTO
                EmployeeDTO newEmployee = new EmployeeDTO
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    RoleName = (cbRole.SelectedItem as RoleDTO).RoleName,
                    DepartmentName = (cbDepartment.SelectedItem as DepartmentDTO).DepartmentName
                };

                // Call your add method here
                employeeService.AddEmployee(newEmployee);

                // Refresh the DataGrid
                dataGridEmployees.ItemsSource = employeeService.GetAllEmployees();
            }
        }

        private void btnUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridEmployees.SelectedItem is EmployeeDTO selectedEmployee)
            {
                // Check if any changes have been made using equals for text read
                if (selectedEmployee.FirstName.Equals(txtFirstName.Text) &&
                                       selectedEmployee.LastName.Equals(txtLastName.Text) &&
                                                          selectedEmployee.RoleName.Equals((cbRole.SelectedItem as RoleDTO).RoleName) &&
                                                                             selectedEmployee.DepartmentName.Equals((cbDepartment.SelectedItem as DepartmentDTO).DepartmentName))
                {
                    MessageBox.Show("No changes have been made.");
                }

                else
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to update?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        // Update the selected employee
                        selectedEmployee.FirstName = txtFirstName.Text;
                        selectedEmployee.LastName = txtLastName.Text;
                        // Get value instead of WTFBO.DTO.RoleDTO 
                        selectedEmployee.RoleName = (cbRole.SelectedItem as RoleDTO).RoleName;
                        selectedEmployee.DepartmentName = (cbDepartment.SelectedItem as DepartmentDTO).DepartmentName;

                        // Call your update method here
                        employeeService.UpdateEmployee(selectedEmployee);

                        // Refresh the DataGrid
                        dataGridEmployees.ItemsSource = employeeService.GetAllEmployees();
                    }
                }
            }
        }



        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridEmployees.SelectedItem is EmployeeDTO selectedEmployee)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // Call your delete method here
                    employeeService.DeleteEmployee(selectedEmployee.EmployeeID);

                    // Refresh the DataGrid
                    dataGridEmployees.ItemsSource = employeeService.GetAllEmployees();
                }
            }
        }

        // DEPARTMENT BTN

        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to add?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                DepartmentDTO newDepartment = new DepartmentDTO
                {
                    DepartmentName = txtDepartmentName.Text
                };

                // Call your add method here
                departmentService.AddDepartment(newDepartment);

                // Refresh the DataGrid
                dataGridDepartments.ItemsSource = departmentService.GetAllDepartments();
            }
        }

        private void btnUpdateDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDepartments.SelectedItem is DepartmentDTO selectedDepartment)
            {
                // Check if any changes have been made
                if (selectedDepartment.DepartmentName.Equals(txtDepartmentName.Text))
                {
                    MessageBox.Show("No changes have been made.");
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to update?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        // Update the selected department
                        selectedDepartment.DepartmentName = txtDepartmentName.Text;

                        // Call your update method here
                        departmentService.UpdateDepartment(selectedDepartment);

                        // Refresh the DataGrid
                        dataGridDepartments.ItemsSource = departmentService.GetAllDepartments();
                    }
                }
            }
        }

        private void btnDeleteDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDepartments.SelectedItem is DepartmentDTO selectedDepartment)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // Call your delete method here
                    departmentService.DeleteDepartment(selectedDepartment.DepartmentID);

                    // Refresh the DataGrid
                    dataGridDepartments.ItemsSource = departmentService.GetAllDepartments();
                }
            }
        }

        // SEARCH BTN

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        // ROLES OPERATION BTN

        private void btnAddRole_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to add?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                RoleDTO newRole = new RoleDTO
                {
                    RoleName = txtRoleName.Text
                };

                // Call your add method here
                roleService.AddRole(newRole);

                // Refresh the DataGrid
                dataGridRoles.ItemsSource = roleService.GetRoles();
            }
        }

        private void btnUpdateRole_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridRoles.SelectedItem is RoleDTO selectedRole)
            {
                // Check if any changes have been made
                if (selectedRole.RoleName.Equals(txtRoleName.Text))
                {
                    MessageBox.Show("No changes have been made.");
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to update?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        // Update the selected role
                        selectedRole.RoleName = txtRoleName.Text;

                        // Call your update method here
                        roleService.UpdateRole(selectedRole);

                        // Refresh the DataGrid
                        dataGridRoles.ItemsSource = roleService.GetRoles();
                    }
                }
            }
        }

        private void btnDeleteRole_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridRoles.SelectedItem is RoleDTO selectedRole)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // Call your delete method here
                    roleService.DeleteRole(selectedRole.RoleID);

                    // Refresh the DataGrid
                    dataGridRoles.ItemsSource = roleService.GetRoles();
                }
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            employeeService.ClearEmployeeSession();

            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}