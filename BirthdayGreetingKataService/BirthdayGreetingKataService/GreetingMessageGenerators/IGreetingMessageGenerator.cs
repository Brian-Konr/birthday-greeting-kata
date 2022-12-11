using BirthdayGreetingKataService.Models;

namespace BirthdayGreetingKataService.GreetingMessageGenerators
{
    public interface IGreetingMessageGenerator
    {
        Response GenerateGreetingMessage(Member member);
    }
}
