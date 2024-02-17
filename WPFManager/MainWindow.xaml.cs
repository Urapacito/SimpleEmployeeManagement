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
using WPFService.EmployeeService;
using WPFService.TeamsService;

namespace WPFManager
{

    public partial class MainWindow : Window
    {

        private readonly ITeamsService teamsService = null;

        public event EventHandler LogoutRequested;

        public MainWindow(int employeeId)
        {
            InitializeComponent();
            teamsService = new TeamsService();

            var teamInfo = teamsService.GetTeamByManagerID(employeeId);
            dataGridTeamMembers.ItemsSource = teamInfo.TeamMembers;
            // Show the team name in the TextBox
            txtTeamName.Text = teamInfo.TeamName;
            txtManagerID.Text = employeeId.ToString();

        }

        private void dataGridTeamMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            // Get the current team name from the data source
            var currentTeam = teamsService.GetTeamByManagerID(int.Parse(txtManagerID.Text));

            // Check if the team name textbox has any changes
            if (txtTeamName.Text == currentTeam.TeamName)
            {
                // If no changes, show a message box
                MessageBox.Show("No changes found");
            }
            else
            {
                // If there are changes, ask the user if they want to update
                var result = MessageBox.Show("Do you want to update?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // If Yes, update the team name
                    teamsService.UpdateTeamName(currentTeam.TeamID, txtTeamName.Text);

                    // Show a message box to confirm the update
                    MessageBox.Show("Update team name successfully");
                }
            }
        }




        private void txtTeamName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            teamsService.ClearTeamSession();

            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}