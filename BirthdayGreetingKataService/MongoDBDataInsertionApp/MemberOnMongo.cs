using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBDataInsertionApp
{
    public class MemberOnMongo
    { 
        public ObjectId Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Gender { get; set; }

        public DateTime DateofBirth { get; set; }

        public string Email { get; set; }

        public MemberOnMongo(ObjectId id, string lastName, string firstName, string gender, DateTime dateofBirth, string email)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
            DateofBirth = dateofBirth;
            Email = email;
        }
    }
}
