using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementProjectAPI.Models
{
    public class DatabaseAPP
    {
        public Response GetFullList(SqlConnection sqlcon, int employeeID)
        {
            Response response = new Response();
            try
            {
                sqlcon.Open();
                string query = "SELECT * FROM EmployeeInfo WHERE EmployeeID = @EmployeeID";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                List<Employee> employees = new List<Employee>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Employee employee = new Employee
                        {
                            EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                            EmployeeName = row["EmployeeName"].ToString(),
                            EmployeePosition = row["EmployeePosition"].ToString(),
                            EmployeeSalary = Convert.ToDecimal(row["EmployeeSalary"]),
                            LeaveFrom = row["LeaveFrom"].ToString(),
                            LeaveTo = row["LeaveTo"].ToString(),
                            ApprovalStatus = row["ApprovalStatus"].ToString()
                        };

                        employees.Add(employee);
                    }

                    response.statusCode = 200;
                    response.statusMessage = "Employee data retrieved successfully.";
                    response.EmployeesList = employees;
                }
                else
                {
                    response.statusCode = 404;
                    response.statusMessage = "No employee found with the specified EmployeeID.";
                }
            }
            catch (Exception ex)
            {
                response.statusCode = 500;
                response.statusMessage = "Error retrieving employee data: " + ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
            }

            return response;
        }



        public Response UpdateLeaves(SqlConnection sqlcon, int employeeID, string leaveFrom, string leaveTo)
        {
            Response response = new Response();
            try
            {
                sqlcon.Open();
                string query = "UPDATE EmployeeInfo SET LeaveFrom = @LeaveFrom, LeaveTo = @LeaveTo, ApprovalStatus = 'Pending' WHERE EmployeeID = @EmployeeID";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@LeaveFrom", leaveFrom); 
                cmd.Parameters.AddWithValue("@LeaveTo", leaveTo);     

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    response.statusCode = 200;
                    response.statusMessage = "Leave details updated successfully.";
                }
                else
                {
                    response.statusCode = 404;
                    response.statusMessage = "No employee found with the specified EmployeeID.";
                }
            }
            catch (Exception ex)
            {
                response.statusCode = 500;
                response.statusMessage = "Error updating leave details: " + ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
            }

            return response;
        }


    }
}
