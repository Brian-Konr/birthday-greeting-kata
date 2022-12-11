using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BirthdayGreetingKataService.Models
{
    public class Response
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
