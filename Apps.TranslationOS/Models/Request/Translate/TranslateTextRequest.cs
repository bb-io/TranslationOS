using Apps.TranslationOS.Models.Request.Translate.Base;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Models.Request.Translate;

public class TranslateTextRequest : TranslateRequest
{
    [JsonProperty("content")] public string Content { get; set; }

    public TranslateTextRequest()
    {
    }

    public TranslateTextRequest(TranslateRequest requestData) : base(requestData)
    {
    }
}