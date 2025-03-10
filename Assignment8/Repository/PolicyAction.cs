using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Assignment8.Interface;
using Assignment8.Model;
using Assignment8.Utility;

namespace Assignment8.Repository
{
    internal class PolicyAction : IPolicy
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public bool AddNewPolicy(int customerId, string name, int policyType, int policyPeriod)
        {
            using (sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO Policies VALUES (@CustomerId,@HolderName,@PolicyType,@StartDate, @EndDate)";
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@HolderName", name);
                cmd.Parameters.AddWithValue("@PolicyType", policyType);
                DateTime startDate = DateTime.Now;
                cmd.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@EndDate", startDate.AddYears(policyPeriod).ToString("yyyy-MM-dd"));
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int effectedRow = cmd.ExecuteNonQuery();
                return (effectedRow > 0);
            }
        }

        public List<Policy> ViewAllPolicy(int customerId)
        {
            using (sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM Policies WHERE UserId = @CustomerId";
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Policy> policies = new List<Policy>();
                while (reader.Read())
                {
                    policies.Add(new Policy
                    {
                        PolicyId = (int)reader["PolicyId"],
                        CustomerId = (int)reader["UserId"],
                        HolderName = reader["HolderName"].ToString(),
                        Type = (int)reader["Type"],
                        StartDate = Convert.ToDateTime(reader["StartDate"].ToString()),
                        EndDate = Convert.ToDateTime(reader["EndDate"].ToString())
                    });
                }
                return policies;
            }
        }
        public List<Policy> SearchPolicyById(int customerId, int id)
        {            
            using (sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM Policies WHERE UserId = @CustomerId AND PolicyId = @Id";
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Policy> policies = new List<Policy>();
                while (reader.Read())
                {
                    policies.Add(new Policy
                    {
                        PolicyId = (int)reader["PolicyId"],
                        CustomerId = (int)reader["UserId"],
                        HolderName = reader["HolderName"].ToString(),
                        Type = (int)reader["Type"],
                        StartDate = Convert.ToDateTime(reader["StartDate"].ToString()),
                        EndDate = Convert.ToDateTime(reader["EndDate"].ToString())
                    });
                }
                return policies;
            }
        }
        public bool UpdatePolicyById(int customerId, int id)
        {
            int isValid = 0;
            using (sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT COUNT(PolicyId) FROM Policies WHERE UserId = @CustomerId AND PolicyId = @Id";
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                isValid = (int)cmd.ExecuteScalar();
            }
            if(isValid > 0)
            {
                Policy policy = new Policy();
                using (sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString()))
                {
                    cmd = new SqlCommand();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT TOP 1 * FROM Policies WHERE UserId = @CustomerId AND PolicyId = @Id";
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        policy.HolderName = reader.GetString("HolderName");
                        policy.Type = reader.GetInt32("Type");
                        policy.StartDate = reader.GetDateTime("StartDate");
                        policy.EndDate = reader.GetDateTime("EndDate");
                    }
                }
                Console.Write("Holder name : ");
                string holderName = Console.ReadLine();
                if (!string.IsNullOrEmpty(holderName))
                {
                    policy.HolderName = holderName;
                }
                Console.Write("Type : ");
                bool isType = int.TryParse(Console.ReadLine(), out int type);
                if (isType)
                {
                    policy.Type = type;
                }
                Console.Write("Period : ");
                bool isPeriod = int.TryParse(Console.ReadLine(), out int period);
                if (isPeriod)
                {
                    policy.EndDate = policy.StartDate.AddYears(period);
                }
                using (sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString()))
                {
                    cmd = new SqlCommand();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Policies SET HolderName = @HolderName,Type = @PolicyType,EndDate = @EndDate WHERE UserId = @CustomerId AND PolicyId = @Id";
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@HolderName", policy.HolderName);
                    cmd.Parameters.AddWithValue("@PolicyType", policy.Type);
                    cmd.Parameters.AddWithValue("@EndDate", policy.EndDate.ToString("yyyy-MM-dd"));
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int effectedRow = cmd.ExecuteNonQuery();
                    return (effectedRow > 0);
                }
            }
            return false;
        }
        public bool DeletPolicy(int customerId, int policyId)
        {
            using (sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM Policies WHERE PolicyId = @PolicyId AND UserId = @Id";
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                cmd.Parameters.AddWithValue("@Id", customerId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int effectedRow = cmd.ExecuteNonQuery();
                return (effectedRow > 0);
            }
        }

        public List<Policy> ShowActivePolicy(int customerId)
        {
            using (sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString()))
            {
                cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM Policies WHERE UserId = @CustomerId AND (@Now BETWEEN StartDate AND EndDate)";
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@Now", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Policy> policies = new List<Policy>();
                while (reader.Read())
                {
                    policies.Add(new Policy
                    {
                        PolicyId = (int)reader["PolicyId"],
                        CustomerId = (int)reader["UserId"],
                        HolderName = reader["HolderName"].ToString(),
                        Type = (int)reader["Type"],
                        StartDate = Convert.ToDateTime(reader["StartDate"].ToString()),
                        EndDate = Convert.ToDateTime(reader["EndDate"].ToString())
                    });
                }
                return policies;
            }
        }
    }
}
