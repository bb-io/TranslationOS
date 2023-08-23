using Blackbird.Applications.Sdk.Utils.Parsers;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Models.Request.TranslationManagement;

public class CancelTranslationRequest
{
    [JsonProperty("id")]
    public long Id { get; set; }
    
    public CancelTranslationRequest(CancelTranslationInput input)
    {
        Id = LongParser.Parse(input.Id, nameof(input.Id))!.Value;
    }
}