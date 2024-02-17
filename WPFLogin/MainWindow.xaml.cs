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
using WPFDAO.SimpleSecurityDAO;
using WPFService.EmployeeService;
using WPFService.SimpleSecurityService;

namespace WPFLogin
{

    public partial class MainWindow : Window
    {
        private readonly ISimpleSecurityService simpleSecurityService = null;

        private readonly IEmployeeService employeeService = null;

        public MainWindow()
        {
            InitializeComponent();
            simpleSecurityService = new SimpleSecurityService();
            employeeService = new EmployeeService();

        }

        private void OnLogoutRequested(object sender, EventArgs e)
        {
            // Clear any user data or session data in login window
            txtUsername.Text = "";
            pbPassword.Password = "";

            // Show the login window again
            this.Show();

            // Close the window that requested logout
            // Assuming you know the reference to the requesting window
            (sender as Window)?.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Get the entered username and password
            string username = txtUsername.Text;
            string password = pbPassword.Password;

            // Get the role of the user
            string role = simpleSecurityService.GetUserRole(username, password);
            int employeeId = employeeService.GetEmployeeID(username, password);

            // Check the role of the user and redirect to the appropriate page
            if (role == "Admin")
            {
                // If the user is an admin, open the WPFEmpManager MainWindow and close the login window
                WPFEmpManager.MainWindow mainWindow = new WPFEmpManager.MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else if (role == "Manager")
            {
                // If the user is a manager, open the ManagerWindow (replace with your actual window for managers)
/*                ManagerWindow managerWindow = new ManagerWindow();
                managerWindow.Show();
                this.Close();*/
            }
            else if (role == "Employee")
            {
                // If the user is an employee, open the EmployeeWindow (replace with your actual window for employees)
                WPFEmployee.MainWindow employeeWindow = new WPFEmployee.MainWindow(employeeId);
                employeeWindow.LogoutRequested += OnLogoutRequested;
                employeeWindow.Show();
                this.Hide();
            }
            else
            {
                // If the user's role is not recognized or the username and password are incorrect, show an error message
                MessageBox.Show("Invalid username or password.");
            }
        }

    }
}