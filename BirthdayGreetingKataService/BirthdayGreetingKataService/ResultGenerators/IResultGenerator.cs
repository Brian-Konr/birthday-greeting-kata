using BirthdayGreetingKataService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayGreetingKataService.ResultGenerators
{
    public interface IResultGenerator
    {
        ActionResult GenerateResults(List<Response> responses);

    }
}
