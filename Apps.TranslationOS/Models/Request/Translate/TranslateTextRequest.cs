using System.Text;
using Apps.TranslationOS.Models.Request.Translate.Base;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Models.Request.Translate;

public class TranslateTextRequest : TranslateRequest
{
    [JsonProperty("content")] public string Content { get; set; }

    public TranslateTextRequest()
    {
    }

    public TranslateTextRequest(TranslateFileRequest requestData) : base(requestData)
    {
        Content = Encoding.UTF8.GetString(requestData.File.Bytes);
    }
}