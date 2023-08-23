using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Models.Request.TranslationManagement;

public class UpdateSet
{
    [JsonProperty("id_order")]
    [Display("Order ID")]
    public string? IdOrder { get; set; }

    [JsonProperty("id_order_group")]
    [Display("Order group ID")]
    public string? IdOrderGroup { get; set; }

    [JsonProperty("dashboard_query_labels")]
    [Display("Dashboard query labels")]
    public IEnumerable<string>? DashboardQueryLabels { get; set; }

    [JsonProperty("callback_url")]
    [Display("Callback URL")]
    public string? CallbackUrl { get; set; }

    [JsonProperty("metadata")] public string? Metadata { get; set; }
}