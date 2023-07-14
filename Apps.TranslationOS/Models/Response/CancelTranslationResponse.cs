using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.TranslationOS.Models.Response;

public class CancelTranslationResponse
{
    [JsonPropertyName("id_request")]
    [Display("Request ids")]
    public IEnumerable<long> IdRequest { get; set; }
    
    [JsonPropertyName("status")]
    [Display("Current status of request")]
    public string Status { get; set; }
    
    [JsonPropertyName("message")]
    public string Message { get; set; }
}