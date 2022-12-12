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
                content = $"Happy birthday, dear {member.FirstName}!\nWe offer special discount 20% off for the following items:\nWhite Wine, iPhone X";
            }
            else if (member.Gender == "Female")
            {
                content = $"Happy birthday, dear {member.FirstName}!\nWe offer special discount 50% off for the following items:\nCosmetic, LV Handbags";
            }
            else
            {
                content = $"Happy birthday, dear {member.FirstName}!";
            }
            return new Response(Constants.MessageTitle, content);
        }
    }
}
