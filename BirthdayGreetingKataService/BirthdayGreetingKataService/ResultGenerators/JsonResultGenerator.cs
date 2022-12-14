using BirthdayGreetingKataService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayGreetingKataService.ResultGenerators
{
    public class JsonResultGenerator : IResultGenerator
    {
        public ActionResult GenerateResults(List<Response> responses)
        {
            JsonResult result = new JsonResult(responses);
            result.StatusCode = 200;
            if (responses.Count == 0) 
            {
                result.StatusCode = 404;
            }
            return result;

        }
    }
}
