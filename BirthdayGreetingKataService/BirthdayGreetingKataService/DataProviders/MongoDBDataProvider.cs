using BirthdayGreetingKataService.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BirthdayGreetingKataService.DataProviders
{
    public class MongoDBDataProvider : IDataProvider
    {
        private readonly IMongoCollection<Member> _members;
        
        public MongoDBDataProvider(IConfiguration configuration) 
        {
            string connectionString = configuration.GetConnectionString("MongoDBCon");
            string password = File.ReadAllText(configuration.GetConnectionString("MongoSecretFilePath"));
            connectionString = connectionString.Replace($"{{YOUR_PASSWORD}}", password);

            // create mongo client
            MongoClient mongoClient = new MongoClient(connectionString);
            IMongoDatabase database = mongoClient.GetDatabase("test");
            _members = database.GetCollection<Member>("members");
        }
        public List<Member> FilterMembers(int? month, int? day, string? gender, bool? isElder)
        {
            return new List<Member>();
        }
    }
}
