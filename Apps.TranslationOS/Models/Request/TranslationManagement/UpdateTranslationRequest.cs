using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.TranslationOS.Models.Request.TranslationManagement;

public class UpdateTranslationRequest
{
    [JsonPropertyName("id_request")]
    [Display("Request id")]
    public long IdRequest { get; set; }
    
    [JsonPropertyName("set")]
    public UpdateSet Set { get; set; }
}