using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.TranslationOS.Webhooks.Payload;

public class TranslationFinished
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("id_content")]
    [Display("Id content")]
    public long IdContent { get; set; }

    [JsonPropertyName("source_language")]
    [Display("Source language")]
    public string SourceLanguage { get; set; }

    [JsonPropertyName("target_language")]
    [Display("Target language")]
    public string TargetLanguage { get; set; }

    [JsonPropertyName("original_content")]
    [Display("Original content")]
    public string OriginalContent { get; set; }

    [JsonPropertyName("translated_content")]
    [Display("Translated content")]
    public string TranslatedContent { get; set; }
}