using System.Text;
using System.Text.Json.Serialization;
using Apps.TranslationOS.Models.Request.Translate.Base;

namespace Apps.TranslationOS.Models.Request.Translate;

public class TranslateTextRequest : TranslateRequest
{
    
    [JsonPropertyName("content")]
    public string Content { get; set; }
    
    public TranslateTextRequest(TranslateFileRequest requestData) : base(requestData)
    {
        Content = Encoding.UTF8.GetString(requestData.File);
    }
}