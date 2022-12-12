using BirthdayGreetingKataService.Models;
using Npgsql;
using System.Data;
using System.Text;

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
            string sqlString = "SELECT * FROM members WHERE ";
            StringBuilder query = new StringBuilder();
            if (month != null)
            {
                query.Append($"EXTRACT (MONTH FROM \"DateofBirth\") = {month} ");
            }
            if (day != null)
            {
                if(query.Length > 0)
                {
                    query.Append("AND ");
                }
                query.Append($"EXTRACT (DAY FROM \"DateofBirth\") = {day} ");
            }
            sqlString += query.ToString();

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (NpgsqlCommand sqlCommand = new NpgsqlCommand(sqlString, connection))
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
