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
            string sqlString = "SELECT * FROM members";
            if (month != null || day != null || gender != null || (isElder != null && isElder.Value))
            {
                sqlString += " WHERE ";
            }
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
            if (gender != null)
            {
                if (query.Length > 0)
                {
                    query.Append("AND ");
                }
                query.Append($"\"Gender\" = '{gender}'");
            }
            if (isElder != null && isElder.Value)
            {
                string currentDateString = DateTime.Now.ToString("yyyy-MM-dd");

                if (query.Length > 0)
                {
                    query.Append("AND ");
                }
                query.Append($"DATE_PART('YEAR', AGE('{currentDateString}', \"DateofBirth\")) > 49");
            }
            sqlString += query.ToString();

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (NpgsqlCommand sqlCommand = new NpgsqlCommand(sqlString, connection))
                {
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
