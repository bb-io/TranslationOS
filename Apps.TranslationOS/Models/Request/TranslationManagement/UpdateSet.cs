using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.TranslationOS.Models.Request.TranslationManagement;

public class UpdateSet
{
    [JsonPropertyName("id_order")]
    [Display("Id order")]
    public string? IdOrder { get; set; }

    [JsonPropertyName("id_order_group")]
    [Display("Id order group")]
    public string? IdOrderGroup { get; set; }

    [JsonPropertyName("dashboard_query_labels")]
    [Display("Dashboard query labels")]
    public IEnumerable<string>? DashboardQueryLabels { get; set; }

    [JsonPropertyName("callback_url")]
    [Display("Callback url")]
    public string? CallbackUrl { get; set; }

    [JsonPropertyName("metadata")] public string? Metadata { get; set; }
}