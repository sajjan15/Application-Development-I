
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

namespace EmployeeManagementProject.EmployeeWindow
{
    /// <summary>
    /// Interaction logic for EmployeeWindows.xaml
    /// </summary>
    public partial class EmployeeWindows : Window
    {
        HttpClient httpClient = new HttpClient();
        public EmployeeWindows()
        {
            InitializeComponent();
            httpClient.BaseAddress = new Uri("https://localhost:7268/api/Employee/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers
                .MediaTypeWithQualityHeaderValue("application/json"));
        }


        private async void LoadData_Button_Click(object sender, RoutedEventArgs e)
        {
            int empID = int.Parse(EmployeeID_textBox.Text);
            var response = await httpClient.GetStringAsync("GetEmployeeInfo/" + empID);
            Response res = JsonConvert.DeserializeObject<Response>(response);
            if (res != null)
            {
                MessageBox.Show(res.statusCode.ToString() +
                    " " + res.statusMessage);
                EmployeeDataGrid.Visibility = Visibility.Visible;
                EmployeeDataGrid.ItemsSource = res.EmployeesList;
                DataContext = this;

            }
            else
            {
                MessageBox.Show("Data Connection Error");
            }


        }


        private async void submit_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int EmpID = int.Parse(EmployeeID_textBox.Text);

                Employee emp = new Employee
                {
                    EmployeeID = EmpID,
                    EmployeeName = "",
                    EmployeePosition = "",
                    EmployeeSalary = 000,
                    LeaveFrom = from_datepicker.SelectedDate.Value.ToString("dd-MM-yyyy"),
                    LeaveTo = to_datepicker.SelectedDate.Value.ToString("dd-MM-yyyy"),
                    ApprovalStatus = "Pending"

                };

                string json = JsonConvert.SerializeObject(emp);

                Console.WriteLine(json);

                using StringContent jsonContent = new(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var response = await httpClient.PostAsync(
                    "UpdateLeaves/", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Leave updated successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to update leave. Status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
    


