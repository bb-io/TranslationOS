using System.Text.Json.Serialization;

namespace Apps.TranslationOS.Models.Request;

public class Error
{
    [JsonPropertyName("message")]
    public string Message { get; set; }
    
    [JsonPropertyName("code")]
    public string Code { get; set; }
}