using BirthdayGreetingKataService.Models;

namespace BirthdayGreetingKataService.GreetingMessageGenerators
{
    public class GreetingMessageGeneratorVer2 : IGreetingMessageGenerator
    {
        public Response GenerateGreetingMessage(Member member)
        {
            string content = string.Empty;
            if (member.Gender == "Male")
            {
                content = $"Happy birthday, dear {member.FirstName}!\r\nWe offer special discount 20% off for the following items:\r\nWhite Wine, iPhone X\r\n";
            }
            else if (member.Gender == "Female")
            {
                content = $"Happy birthday, dear {member.FirstName}!\r\nWe offer special discount 50% off for the following items:\r\nCosmetic, LV Handbags\r\n";
            }
            else
            {
                content = $"Happy birthday, dear {member.FirstName}!";
            }
            return new Response(Constants.MessageTitle, content);
        }
    }
}
