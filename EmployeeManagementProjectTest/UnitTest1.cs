using NUnit.Framework.Legacy;
using System.Data.Common;
using System.Data.SqlClient;

namespace EmployeeManagementProjectTest
{
    public class Tests
    {

        private string connectionString = "Data Source=ACER;Initial Catalog=EmployeeManagementProject;Integrated Security=True;";
        private SqlConnection sqlconnection;
        [SetUp]
        public void Setup()
        {
            sqlconnection = new SqlConnection(connectionString);
            sqlconnection.Open();

            using (var command = new SqlCommand("DELETE FROM EmployeeInfo", sqlconnection))
            {
                command.ExecuteNonQuery();
            }

        }

        [Test]
        public void AddEmployee_Database()
        {
            var employeeName = "John Doe";
            var employeePosition = "Developer";
            var employeeSalary = 60000;
            var query = "INSERT INTO EmployeeInfo (EmployeeName, EmployeePosition, EmployeeSalary) VALUES (@EmployeeName, @EmployeePosition, @EmployeeSalary)";


            using (var command = new SqlCommand(query, sqlconnection))
            {
                command.Parameters.AddWithValue("@EmployeeName", employeeName);
                command.Parameters.AddWithValue("@EmployeePosition", employeePosition);
                command.Parameters.AddWithValue("@EmployeeSalary", employeeSalary);
                command.ExecuteNonQuery();
            }

            var checkQuery = "SELECT COUNT(*) FROM EmployeeInfo WHERE EmployeeName = @EmployeeName AND EmployeePosition = @EmployeePosition AND EmployeeSalary = @EmployeeSalary";
            using (var checkCommand = new SqlCommand(checkQuery, sqlconnection))
            {
                checkCommand.Parameters.AddWithValue("@EmployeeName", employeeName);
                checkCommand.Parameters.AddWithValue("@EmployeePosition", employeePosition);
                checkCommand.Parameters.AddWithValue("@EmployeeSalary", employeeSalary);

                var result = (int)checkCommand.ExecuteScalar();
                ClassicAssert.AreEqual(1, result, "Employee record should be inserted into the database.");
            }

        }
        [Test]
        public void DeleteEmployee_ShouldRemoveEmployeeFromDatabase()
        {

           // AddEmployee_Database(); //insert the employee to be deleted
            var employeeName = "John Doe";
            var deleteQuery = "DELETE FROM EmployeeInfo WHERE EmployeeName = @EmployeeName";

            
            using (var command = new SqlCommand(deleteQuery, sqlconnection))
            {
                command.Parameters.AddWithValue("@EmployeeName", employeeName);
                command.ExecuteNonQuery();
            }

            
            var checkQuery = "SELECT COUNT(*) FROM EmployeeInfo WHERE EmployeeName = @EmployeeName";
            using (var checkCommand = new SqlCommand(checkQuery, sqlconnection))
            {
                checkCommand.Parameters.AddWithValue("@EmployeeName", employeeName);
                var result = (int)checkCommand.ExecuteScalar();
                ClassicAssert.AreEqual(0, result, "Employee record should be deleted from the database.");
            }
        }
        [Test]
        public void UpdateEmployeeInDatabase()
        {
            AddEmployee_Database();
            var oldEmployeeName = "Tom Cruise";
            var newEmployeeName = "Robert Downey";
            var updateQuery = "UPDATE EmployeeInfo SET EmployeeName = @NewEmployeeName WHERE EmployeeName = @OldEmployeeName";

            using (var command = new SqlCommand(updateQuery, sqlconnection))
            {
                command.Parameters.AddWithValue("@NewEmployeeName", newEmployeeName);
                command.Parameters.AddWithValue("@OldEmployeeName", oldEmployeeName);
                command.ExecuteNonQuery();
            }

            var checkQuery = "SELECT COUNT(*) FROM EmployeeInfo WHERE EmployeeName = @NewEmployeeName";
            using (var checkCommand = new SqlCommand(checkQuery, sqlconnection))
            {
                checkCommand.Parameters.AddWithValue("@NewEmployeeName", newEmployeeName);
                var result = (int)checkCommand.ExecuteScalar();
                ClassicAssert.AreEqual(0, result, "Employee record should be updated in the database.");
            }
        }
    }
}