using Apps.TranslationOS.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Webhooks.Payload;

public class TranslationPayload
{
    [JsonProperty("id")] 
    [Display("Translation ID")]
    public string Id { get; set; }

    [JsonProperty("id_content")]
    [Display("Content ID")]
    public string IdContent { get; set; }

    [JsonProperty("source_language")]
    [Display("Source language")]
    public string SourceLanguage { get; set; }

    [JsonProperty("target_language")]
    [Display("Target language")]
    public string TargetLanguage { get; set; }

    [JsonProperty("original_content")]
    [Display("Original")]
    public string OriginalContent { get; set; }

    [JsonProperty("translated_content")]
    [Display("Translated content")]
    public string TranslatedContent { get; set; }
}