using BirthdayGreetingKataService.Models;

namespace BirthdayGreetingKataService.GreetingMessageGenerators
{
    public class GreetingMessageGeneratorVer3 : IGreetingMessageGenerator
    {
        public Response GenerateGreetingMessage(Member member)
        {
            string content = $"Happy birthday, dear `{member.FirstName}`!\n(A greeting picture here)\n";
            return new Response(Constants.MessageTitle, content);
        }
    }
}
