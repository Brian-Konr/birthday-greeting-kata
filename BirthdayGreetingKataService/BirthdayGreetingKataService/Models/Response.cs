using System.Text.Json.Serialization;

namespace BirthdayGreetingKataService.Models
{
    public class Response
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        public Response(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Response comparedResponse = obj as Response;
            return Title.Equals(comparedResponse.Title) && Content.Equals(comparedResponse.Content);
        }
    }
}
