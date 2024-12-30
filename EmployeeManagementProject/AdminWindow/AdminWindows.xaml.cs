using EmployeeManagementProject.EmployeeWindow;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace EmployeeManagementProject.AdminWindow
{
    /// <summary>
    /// Interaction logic for AdminWindows.xaml
    /// </summary>
    public partial class AdminWindows : Window
    {
        private SqlConnection connector;
        private SqlCommand command;
        private string connectionString = "Data Source=ACER;Initial Catalog=EmployeeManagementProject;Integrated Security=True;";

        public AdminWindows()
        {
            InitializeComponent();
        }

        private void establishConnection()
        {
            connector = new SqlConnection(connectionString);
            connector.Open();
        }

        private void CloseConnection()
        {
            if (connector != null && connector.State != ConnectionState.Closed)
            {
                connector.Close();
                connector.Dispose();
            }
        }

        private void LoadDataGrid()
        {
            try
            {
                establishConnection();
                string query = "SELECT * FROM EmployeeInfo";
                command = new SqlCommand(query, connector);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Set the DataTable as the ItemsSource for the EmployeeDataGrid
                EmployeeDataGrid.ItemsSource = dataTable.DefaultView;

                // Refresh the EmployeeDataGrid to reflect changes
                EmployeeDataGrid.Items.Refresh();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        private void AddEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnection();
                string query = "INSERT INTO EmployeeInfo (EmployeeName, EmployeePosition, EmployeeSalary) VALUES (@EmployeeName, @EmployeePosition, @EmployeeSalary)";

                using (command = new SqlCommand(query, connector))
                {
                    command.Parameters.AddWithValue("@EmployeeName", EmployeeName_TextBox.Text);
                    command.Parameters.AddWithValue("@EmployeePosition", ((ComboBoxItem)EmployeePosition_ComboBox.SelectedItem).Content.ToString());
                    command.Parameters.AddWithValue("@EmployeeSalary", decimal.Parse(EmployeeSalary_TextBox.Text));

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data Inserted Successfully");
                        LoadDataGrid(); // Refresh the DataGrid after insertion
                    }
                    else
                    {
                        MessageBox.Show("No data was inserted.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please enter valid data: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


        private void UpdateEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnection();
                string query = "UPDATE EmployeeInfo SET EmployeeName = @EmployeeName, EmployeePosition = @EmployeePosition, EmployeeSalary = @EmployeeSalary WHERE EmployeeID = @EmployeeId";

                using (command = new SqlCommand(query, connector))
                {
                    command.Parameters.AddWithValue("@EmployeeId", EmployeeID_TextBox.Text);
                    command.Parameters.AddWithValue("@EmployeeName", EmployeeName_TextBox.Text);
                    command.Parameters.AddWithValue("@EmployeePosition", ((ComboBoxItem)EmployeePosition_ComboBox.SelectedItem).Content.ToString());
                    command.Parameters.AddWithValue("@EmployeeSalary", EmployeeSalary_TextBox.Text);
          
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data Updated Successfully");
                        LoadDataGrid(); // Refresh the DataGrid after update
                    }
                    else
                    {
                        MessageBox.Show("No data was updated.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please enter valid data: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


        private void aproval_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnection();
                string query = "UPDATE EmployeeInfo SET ApprovalStatus = @ApprovalStatus WHERE EmployeeID = @EmployeeId";
                using (command = new SqlCommand(query, connector))
                {
                    if (EmployeeLeaveApproval_ComboBox != null && EmployeeLeaveApproval_ComboBox.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@ApprovalStatus", ((ComboBoxItem)EmployeeLeaveApproval_ComboBox.SelectedItem).Content.ToString());
                        command.Parameters.AddWithValue("@EmployeeId", EmployeeID_TextBox.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Approval Status Updated Successfully");
                            LoadDataGrid(); 
                        }
                        else
                        {
                            MessageBox.Show("No data was updated.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select an approval status.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


        private void LoadDatabase_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void DeleteEmployee_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnection();

                string query = "DELETE FROM EmployeeInfo WHERE EmployeeID = @EmployeeId";

                using (command = new SqlCommand(query, connector))
                {
                    command.Parameters.AddWithValue("@EmployeeId", EmployeeID_TextBox.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data Deleted Successfully");
                        LoadDataGrid(); // Refresh the DataGrid after deletion
                    }
                    else
                    {
                        MessageBox.Show("No data found for deletion.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            Employee emp  = (Employee)e.AddedItems[0];
            if(emp != null) 
            {
                EmployeeID_TextBox.Text = emp.EmployeeID.ToString();
                EmployeeName_TextBox.Text = emp.EmployeeName;
            }
            */

            DataRowView dataRowView = EmployeeDataGrid.SelectedItem as DataRowView;
            if(dataRowView != null)
            {
                EmployeeID_TextBox.Text = dataRowView.Row.ItemArray[0].ToString();
                EmployeeName_TextBox.Text = dataRowView.Row.ItemArray[1].ToString();
                EmployeePosition_ComboBox.Text = dataRowView.Row.ItemArray[2].ToString();
                EmployeeSalary_TextBox.Text = dataRowView.Row.ItemArray[3].ToString();
                EmployeeLeaveApproval_ComboBox.Text = dataRowView.Row.ItemArray[4].ToString();


            } 
        }
    }
}
