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
using WPFRepo;
using WPFDAO.EmployeeDAO;
using WPFService.EmployeeService;
using WPFBO.DTO;

namespace WPFEmployee
{
    public partial class MainWindow : Window
    {

        private readonly IEmployeeService employeeService = null;

        public event EventHandler LogoutRequested;

        public MainWindow(int employeeId)
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            var employeeInfo = employeeService.GetUserInfoById(employeeId);

            // Display the employee's information in the profile card
            txtEmployeeID.Text = employeeInfo.EmployeeID.ToString();
            txtFirstName.Text = employeeInfo.FirstName;
            txtLastName.Text = employeeInfo.LastName;
            txtTeamID.Text = employeeInfo.TeamID.ToString();
            txtRole.Text = employeeInfo.RoleName;
            txtDepartment.Text = employeeInfo.DepartmentName;

            // Display the employee's username and password
            txtUsername.Text = employeeInfo.Username;
            pbPassword.Password = employeeInfo.Password;

        }


        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            // Clear data and session
            txtEmployeeID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtRole.Text = "";
            txtDepartment.Text = "";
            employeeService.ClearEmployeeSession();

            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Check if the user has entered all the required information
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtRole.Text) || string.IsNullOrEmpty(txtDepartment.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(pbPassword.Password))
            {
                MessageBox.Show("Please enter all the required information.");
                return;
            }
            // Create a new instance of EmployeeDTO
            EmployeeDTO updatedEmployee = new EmployeeDTO
            {
                EmployeeID = int.Parse(txtEmployeeID.Text),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                RoleName = txtRole.Text,
                DepartmentName = txtDepartment.Text,
                Username = txtUsername.Text,
                Password = pbPassword.Password
            };

            // Create a new instance of EmployeeService
            EmployeeService employeeService = new EmployeeService();

            // Call the UpdateEmployee method from the EmployeeService instance
            bool isUpdated = employeeService.UpdateEmployee(updatedEmployee);

            // Check if the update was successful
            if (isUpdated)
            {
                MessageBox.Show("Employee details updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update employee details.");
            }
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            pbPassword.Visibility = Visibility.Collapsed;
            tbPassword.Visibility = Visibility.Visible;
            tbPassword.Text = pbPassword.Password;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            tbPassword.Visibility = Visibility.Collapsed;
            pbPassword.Visibility = Visibility.Visible;
            pbPassword.Password = tbPassword.Text;
        }

    }
}
