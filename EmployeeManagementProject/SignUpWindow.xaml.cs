using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmployeeManagementProject
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private SqlConnection connector;
        private SqlCommand command;
        private string connectionString = "Data Source=ACER;Initial Catalog=EmployeeManagementProjectUsers;Integrated Security=True;";

        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void establishConnection()
        {
            connector = new SqlConnection(connectionString);
            connector.Open();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                establishConnection();

                // Check if username already exists
                string checkUserQuery = "SELECT COUNT(*) FROM UserInfo WHERE Username = @Username";
                command = new SqlCommand(checkUserQuery, connector);
                command.Parameters.AddWithValue("@Username", username);
                int userCount = (int)command.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Admin User already exists", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Insert new user
                string insertQuery = "INSERT INTO UserInfo (Username, Password) VALUES (@Username, @Password)";
                command = new SqlCommand(insertQuery, connector);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Registration successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UsernameTextBox.Text = string.Empty;
        }

        private void PasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordTextBox.Text = string.Empty;
        }
    }
}
