using BirthdayGreetingKataService.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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
            var list = _members.Find(member => true).ToList();
            foreach (Member member in list)
            {
                member.DateofBirth = member.DateofBirth.AddHours(8);
            }
            return list.Where(member =>
                (month == null || member.DateofBirth.Month == month) &&
                (day == null || member.DateofBirth.Day == day) &&
                (gender == null || member.Gender == gender) &&
                (isElder == null || !isElder.Value || Utils.GetAgeFromDateofBirth(member.DateofBirth) > Constants.ElderThreshold)
            ).ToList();
        }
    }
}
