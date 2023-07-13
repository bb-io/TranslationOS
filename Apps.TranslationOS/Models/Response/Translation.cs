using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.TranslationOS.Models.Response;

public class Translation
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("id_order")]
    [Display("Id order")]
    public string? IdOrder { get; set; }

    [JsonPropertyName("id_order_group")]
    [Display("Id order group")]
    public string? IdOrderGroup { get; set; }

    [JsonPropertyName("source_language")]
    [Display("Source language")]
    public string SourceLanguage { get; set; }

    [JsonPropertyName("target_language")]
    [Display("Target language")]
    public string TargetLanguage { get; set; }

    [JsonPropertyName("service_type")]
    [Display("Service type")]
    public string ServiceType { get; set; }

    [JsonPropertyName("status")] public string Status { get; set; }

    [JsonPropertyName("dashboard_query_labels")]
    [Display("Dashboard query labels")]
    public IEnumerable<string> DashboardQueryLabels { get; set; }

    [JsonPropertyName("delivery_email")]
    [Display("Delivery email")]
    public string DeliveryEmail { get; set; }

    [JsonPropertyName("events")] public IEnumerable<string>? Events { get; set; }

    [JsonPropertyName("callback_url")]
    [Display("Callback url")]
    public string? CallbackUrl { get; set; }

    [JsonPropertyName("metadata")] public string? Metadata { get; set; }

    [JsonPropertyName("char_limit")]
    [Display("Char limit")]
    public int? CharLimit { get; set; }
}