using BirthdayGreetingKataService.Models;
using Npgsql;
using System.Data;

namespace BirthdayGreetingKataService.DataProviders
{
    public class PostgreSqlDataProvider : IDataProvider
    {
        private readonly string _connectionString;
        public PostgreSqlDataProvider(IConfiguration configuration) 
        {
            string connectionString = configuration.GetConnectionString("PostgresqlCon");
            string password = LoadPassword(configuration.GetConnectionString("PostgreSecretFilePath"));
            _connectionString = connectionString.Replace($"{{YOUR_PASSWORD}}", password);
        }
        public List<Member> FilterMembers(int? month, int? day, string? gender, bool? isElder)
        {
            var filteredMembers = new List<Member>();
            // TODO: handle queries
            string query = @"
                SELECT *
                FROM
                 members
                WHERE
                 EXTRACT (MONTH FROM ""DateofBirth"") = @month AND
                 EXTRACT (DAY FROM ""DateofBirth"") = @day 
            ";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (NpgsqlCommand sqlCommand = new NpgsqlCommand(query, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@month", month);
                    sqlCommand.Parameters.AddWithValue("@day", day);
                    NpgsqlDataReader dataReader = sqlCommand.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string memberFirstName = row.Field<string>("FirstName");
                        string memberLastName = row.Field<string>("LastName");
                        string memberEmail = row.Field<string>("Email");
                        string memberGender = row.Field<string>("Gender");
                        DateTime dateofBirth = row.Field<DateTime>("DateofBirth");
                        Member member = new Member(
                            firstName: memberFirstName,
                            lastName: memberLastName,
                            gender: memberGender,
                            dateofBirth: dateofBirth,
                            email: memberEmail
                        );
                        filteredMembers.Add(member);
                    }
                }
            }
            return filteredMembers;
        }

        private string LoadPassword(string filePath)
        {
            string password = System.IO.File.ReadAllText(filePath);
            return password;
        }
    }
}
