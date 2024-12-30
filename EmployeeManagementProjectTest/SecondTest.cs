using NUnit.Framework.Legacy;
using System.Data.SqlClient;

namespace EmployeeManagementProjectTest
{
    public class SecondTest
    {
        private string connectionString = "Data Source=ACER;Initial Catalog=EmployeeManagementProjectUsers;Integrated Security=True;";
        private SqlConnection sqlconnection;

        [SetUp]
        public void Setup()
        {
            sqlconnection = new SqlConnection(connectionString);
            sqlconnection.Open();

            // Clean up the UserInfo table before each test
            using (var command = new SqlCommand("DELETE FROM UserInfo", sqlconnection))
            {
                command.ExecuteNonQuery();
            }
        }

        [Test]
        public void RegisterUser_ShouldAddUserToDatabase()
        {
            var username = "testuser";
            var password = "password123";
            var query = "INSERT INTO UserInfo (Username, Password) VALUES (@Username, @Password)";

            using (var command = new SqlCommand(query, sqlconnection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.ExecuteNonQuery();
            }

            var checkQuery = "SELECT COUNT(*) FROM UserInfo WHERE Username = @Username AND Password = @Password";
            using (var checkCommand = new SqlCommand(checkQuery, sqlconnection))
            {
                checkCommand.Parameters.AddWithValue("@Username", username);
                checkCommand.Parameters.AddWithValue("@Password", password);

                var result = (int)checkCommand.ExecuteScalar();
                ClassicAssert.AreEqual(1, result, "User record should be inserted into the database.");
            }
        }
    }
}
