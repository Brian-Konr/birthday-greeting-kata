using BirthdayGreetingKataService.Models;

namespace BirthdayGreetingKataService.GreetingMessageGenerators
{
    public class GreetingMessageGeneratorVer4 : IGreetingMessageGenerator
    {
        public Response GenerateGreetingMessage(Member member)
        {
            string content = $"Happy birthday, dear {member.LastName}, {member.FirstName}!";
            return new Response(Constants.MessageTitle, content);
        }
    }
}
