using BirthdayGreetingKataService.Models;

namespace BirthdayGreetingKataService.GreetingMessageGenerators
{
    public class GreetingMessageGeneratorVer1 : IGreetingMessageGenerator
    {
        public Response GenerateGreetingMessage(Member member)
        {
            string content = $"Happy birthday, dear {member.FirstName}!";
            return new Response(Constants.MessageTitle, content);
        }
    }
}
