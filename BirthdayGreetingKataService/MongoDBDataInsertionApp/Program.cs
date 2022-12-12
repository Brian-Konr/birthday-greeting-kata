using BirthdayGreetingKataService;
using BirthdayGreetingKataService.Models;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

// Replace the uri string with your MongoDB deployment's connection string.
string password = File.ReadAllText("C:\\Users\\user\\Documents\\GitHub\\birthday-greeting-kata\\BirthdayGreetingKataService\\BirthdayGreetingKataService\\mongodb_password.txt");
var uri = $"mongodb+srv://briankonr:{password}@cluster0.bnnc5xp.mongodb.net/?retryWrites=true&w=majority";
// instruct the driver to camelCase the fields in MongoDB
var pack = new ConventionPack { new CamelCaseElementNameConvention() };
ConventionRegistry.Register("elementNameConvention", pack, x => true);
var client = new MongoClient(uri);

// database and colletion code goes here
var db = client.GetDatabase("test");
var coll = db.GetCollection<Member>("members");


var data = Utils.GenerateAllMembers();
coll.InsertMany(data);

Console.WriteLine("Data added successfully!...");

