using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Models.Response;

public class Translation
{
    [Display("ID")]
    public string Id { get; set; }

    [JsonProperty("id_order")]
    [Display("Order ID")]
    public string? IdOrder { get; set; }

    [JsonProperty("id_order_group")]
    [Display("Order group ID")]
    public string? IdOrderGroup { get; set; }

    [JsonProperty("source_language")]
    [Display("Source language")]
    public string SourceLanguage { get; set; }

    [JsonProperty("target_language")]
    [Display("Target language")]
    public string TargetLanguage { get; set; }

    [JsonProperty("service_type")]
    [Display("Service type")]
    public string ServiceType { get; set; }

    [JsonProperty("status")] public string Status { get; set; }

    [JsonProperty("dashboard_query_labels")]
    [Display("Dashboard query labels")]
    public IEnumerable<string> DashboardQueryLabels { get; set; }

    [JsonProperty("delivery_email")]
    [Display("Delivery email")]
    public string DeliveryEmail { get; set; }

    [JsonProperty("events")] public IEnumerable<string>? Events { get; set; }

    [JsonProperty("callback_url")]
    [Display("Callback URL")]
    public string? CallbackUrl { get; set; }

    [JsonProperty("metadata")] public string? Metadata { get; set; }

    [JsonProperty("char_limit")]
    [Display("Char limit")]
    public int? CharLimit { get; set; }
}