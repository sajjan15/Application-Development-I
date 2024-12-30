using System.Data.SqlClient;
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
using EmployeeManagementProject.AdminWindow;
using EmployeeManagementProject.EmployeeWindow;

namespace EmployeeManagementProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string connectionString = "Data Source=ACER;Initial Catalog=EmployeeManagementProjectUsers;Integrated Security=True;";
        private SqlConnection connector;
        private SqlCommand command;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            // Placeholder login validation logic
            if (username == "admin" && password == "password")
            {
                AdminWindows adminWindow = new AdminWindows();
                adminWindow.Show();
                this.Close();
            }
            else if(username == "employee" && password == "password")
            {
                EmployeeWindows empWindow = new EmployeeWindows();
                empWindow.Show();
                this.Close();
            }
            else
            {
                try
                {
                    connector = new SqlConnection(connectionString);
                    connector.Open();

                    string checkUserQuery = "SELECT * FROM UserInfo WHERE Username = @Username AND Password = @Password";
                    command = new SqlCommand(checkUserQuery, connector);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        AdminWindows adminWindow = new AdminWindows();
                        adminWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (connector != null && connector.State == System.Data.ConnectionState.Open)
                    {
                        connector.Close();
                    }
                }
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow registrationWindow = new SignUpWindow();
            registrationWindow.Show();
        }

        private void AdminInfoButton_Click(object sender, RoutedEventArgs e)
        {
            string inputUsername = Microsoft.VisualBasic.Interaction.InputBox("Enter admin username:", "Authentication Required", "");
            string inputPassword = Microsoft.VisualBasic.Interaction.InputBox("Enter admin password:", "Authentication Required", "");

            if (inputUsername == "admin" && inputPassword == "password")
            {
                AdminInfoWindow adminInfoWindow = new AdminInfoWindow();
                adminInfoWindow.Show();
            }
            else
            {
                MessageBox.Show("Authentication failed. Access denied.", "Authentication Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}