using BirthdayGreetingKataService.Models;

namespace BirthdayGreetingKataService.GreetingMessageGenerators
{
    public interface IGreetingMessageGenerator
    {
        string GenerateGreetingMessage(Member member);
    }
}
