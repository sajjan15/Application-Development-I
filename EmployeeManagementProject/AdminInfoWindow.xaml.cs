using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeManagementProject
{
    public partial class AdminInfoWindow : Window
    {
        private string connectionString = "Data Source=ACER;Initial Catalog=EmployeeManagementProjectUsers;Integrated Security=True;";
        private SqlConnection connector;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private DataTable adminsTable;

        public AdminInfoWindow()
        {
            InitializeComponent();
            LoadAdminData();
        }

        private void LoadAdminData()
        {
            try
            {
                connector = new SqlConnection(connectionString);
                connector.Open();

                string query = "SELECT * FROM UserInfo WHERE Username != 'admin'";
                command = new SqlCommand(query, connector);
                adapter = new SqlDataAdapter(command);
                adminsTable = new DataTable();
                adapter.Fill(adminsTable);
                AdminDataGrid.ItemsSource = adminsTable.DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (connector != null && connector.State == ConnectionState.Open)
                {
                    connector.Close();
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdminDataGrid.SelectedItem is DataRowView selectedRow)
            {
                string username = selectedRow["Username"].ToString();
                string newUsername = Microsoft.VisualBasic.Interaction.InputBox("Enter new username:", "Update Username", username);

                if (!string.IsNullOrWhiteSpace(newUsername) && newUsername != username)
                {
                    try
                    {
                        connector = new SqlConnection(connectionString);
                        connector.Open();

                        string query = "UPDATE UserInfo SET Username = @NewUsername WHERE Username = @OldUsername";
                        command = new SqlCommand(query, connector);
                        command.Parameters.AddWithValue("@NewUsername", newUsername);
                        command.Parameters.AddWithValue("@OldUsername", username);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Username updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadAdminData();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        if (connector != null && connector.State == ConnectionState.Open)
                        {
                            connector.Close();
                        }
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdminDataGrid.SelectedItem is DataRowView selectedRow)
            {
                string username = selectedRow["Username"].ToString();

                if (username == "admin")
                {
                    MessageBox.Show("You cannot delete the main admin user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var result = MessageBox.Show($"Are you sure you want to delete {username}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        connector = new SqlConnection(connectionString);
                        connector.Open();

                        string query = "DELETE FROM UserInfo WHERE Username = @Username";
                        command = new SqlCommand(query, connector);
                        command.Parameters.AddWithValue("@Username", username);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Admin deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadAdminData();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        if (connector != null && connector.State == ConnectionState.Open)
                        {
                            connector.Close();
                        }
                    }
                }
            }
        }
    }
}
