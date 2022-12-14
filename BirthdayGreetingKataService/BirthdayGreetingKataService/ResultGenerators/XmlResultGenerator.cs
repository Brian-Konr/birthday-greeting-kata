using BirthdayGreetingKataService.Models;
using BirthdayGreetingKataService.ResultGenerators;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Serialization;

namespace BirthdayGreetingKataService.Results
{
    public class XmlResultGenerator : IResultGenerator
    {
        public ActionResult GenerateResults(List<Response> responses)
        {
            ResponseWrapper wrapper = new ResponseWrapper(responses);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ResponseWrapper));
            using StringWriter stringWriter = new Utf8StringWriter();
            xmlSerializer.Serialize(stringWriter, wrapper);
            string content = stringWriter.ToString();
            return responses.Count > 0 ? new ContentResult() { StatusCode = 200, Content = content } : new ContentResult() { StatusCode = 404, Content = content };
        }
    }
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
