using MongoDB.Bson.Serialization.Attributes;

namespace BirthdayGreetingKataService.Models
{
    /// <summary>
    /// 每一個 Member 物件對應到資料庫的一筆 data row
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Member
    {
        [BsonElement("firstName")]
        public string LastName { get; set; }

        [BsonElement("lastName")]
        public string FirstName { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("dateofBirth")]
        public DateTime DateofBirth { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        public Member(string lastName, string firstName, string gender, DateTime dateofBirth, string email)
        {
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
            DateofBirth = dateofBirth;
            Email = email;
        }
    }
}
