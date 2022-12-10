using BirthdayGreetingKataService.Models;

namespace BirthdayGreetingKataService.DataProviders
{
    public class PostgreSqlDataProvider : IDataProvider
    {
        public List<Member> FilterMembersByDateofBirth(int month, int day)
        {
            throw new NotImplementedException();
        }

        public List<Member> FilterMembersByElder(int threshold = 49)
        {
            throw new NotImplementedException();
        }

        public List<Member> FilterMembersByGender(string gender)
        {
            throw new NotImplementedException();
        }
    }
}
