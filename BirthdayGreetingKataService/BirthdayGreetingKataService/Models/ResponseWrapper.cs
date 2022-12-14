using System.Xml.Serialization;

namespace BirthdayGreetingKataService.Models
{
    [XmlRoot("root")]
    public class ResponseWrapper
    {
        [XmlArray("MessageList"), XmlArrayItem(typeof(Response), ElementName = "Message")]
        public List<Response> Responses { get; set; }

        public ResponseWrapper()
        {
            Responses = new List<Response>();
        }
        public ResponseWrapper(List<Response> responses)
        {
            Responses = responses;
        }
    }
}
