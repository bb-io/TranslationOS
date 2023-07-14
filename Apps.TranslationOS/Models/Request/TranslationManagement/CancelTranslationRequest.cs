using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.TranslationOS.Models.Request.TranslationManagement;

public class CancelTranslationRequest
{
    [JsonPropertyName("id")]
    [Display("Request id")]
    public long Id { get; set; }
}