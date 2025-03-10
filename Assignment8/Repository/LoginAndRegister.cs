using System.Data.SqlClient;
using Assignment8.Interface;
using Assignment8.Model;
using Assignment8.Utility;

namespace Assignment8.Repository
{
    internal class LoginAndRegister : ILoginAndRegister
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public bool Loggin(int id, string password)
        {
            using (sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT COUNT(UserId) FROM Users WHERE UserId = @Id AND Password = @Password";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue ("@Password", password);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int isValidUser = (int)cmd.ExecuteScalar();
                return (isValidUser > 0);
            }
        }

        public void Register(string name, string password)
        {
            using (sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO Users VALUES (@Name,@Password);SELECT CAST(SCOPE_IDENTITY() AS INT)";
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int id = (int)cmd.ExecuteScalar();
                Console.WriteLine("\nYour unique ID : " + id);
            }
        }
    }
}
