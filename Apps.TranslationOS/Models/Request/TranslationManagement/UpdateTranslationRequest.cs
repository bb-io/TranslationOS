using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Models.Request.TranslationManagement;

public class UpdateTranslationRequest
{
    [JsonProperty("id_request")]
    [Display("Request")]
    public long IdRequest { get; set; }
    
    [JsonProperty("set")]
    public UpdateSet Set { get; set; }
}