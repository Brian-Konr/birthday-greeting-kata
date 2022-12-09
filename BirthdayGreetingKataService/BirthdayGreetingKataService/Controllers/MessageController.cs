using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirthdayGreetingKataService.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _postgresPassword;
        public MessageController(IConfiguration configuration)
        {
            _configuration= configuration;
            string secrectFilePath = _configuration.GetConnectionString("PostgreSecretFilePath");
            _postgresPassword = LoadPassword(secrectFilePath);
        }

        // GET: api/<MessageController>
        [HttpGet]
        public IEnumerable<string> Get(
            [FromQuery(Name = "month")] int month,
            [FromQuery(Name = "day")] int day
        )
        {
            string query = @"
                SELECT * 
                FROM 
                    members
            ";

            string sqlDataSource = _configuration.GetConnectionString("PostgresqlCon");
            // replace {YOUR_PASSWORD} with real password
            sqlDataSource = sqlDataSource.Replace($"{{YOUR_PASSWORD}}", _postgresPassword);
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand sqlCommand = new NpgsqlCommand(query, connection))
                {
                    NpgsqlDataReader dataReader = sqlCommand.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                }
            }
            return new string[] { "value1", "value2" };
        }
        
        private string LoadPassword(string filePath)
        {
            string password = System.IO.File.ReadAllText(filePath);
            return password;
        }
    }
}
