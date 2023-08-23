using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Models.Response;

public class CancelTranslationResponse
{
    [JsonProperty("id_request")]
    [Display("Request IDs")]
    public IEnumerable<string> IdRequest { get; set; }
    
    [JsonProperty("status")]
    [Display("Current status of request")]
    public string Status { get; set; }
    
    [JsonProperty("message")]
    public string Message { get; set; }
}