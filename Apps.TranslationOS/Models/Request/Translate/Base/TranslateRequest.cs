using Apps.TranslationOS.DataSourceHandlers;
using Apps.TranslationOS.DataSourceHandlers.EnumDataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Models.Request.Translate.Base;

public class TranslateRequest
{
    [JsonProperty("id_content")]
    [Display("Content ID")]
    public string IdContent { get; set; }

    [JsonProperty("source_language")]
    [Display("Source language")]
    [DataSource(typeof(LanguageDataHandler))]
    public string SourceLanguage { get; set; }

    [JsonProperty("target_languages")]
    [Display("Target languages")]
    public IEnumerable<string> TargetLanguages { get; set; }

    [JsonProperty("service_type")]
    [Display("Service type")]
    [DataSource(typeof(ServiceTypeDataHandler))]
    public string ServiceType { get; set; }

    [JsonProperty("id_order")]
    [Display("Order ID")]
    public string? IdOrder { get; set; }

    [JsonProperty("id_order_group")]
    [Display("Order group ID")]
    public string? IdOrderGroup { get; set; }

    [JsonProperty("content_type")]
    [Display("Content type")]
    [DataSource(typeof(ContentTypeDataHandler))]
    public string? ContentType { get; set; }

    [JsonProperty("context")]
    [Display("Content")]
    public Context? Context { get; set; }

    [JsonProperty("purchase_order")]
    [Display("Purchase order")]
    public string? PurchaseOrder { get; set; }

    [JsonProperty("cost_attribution_label")]
    [Display("Cost attribution label")]
    public string? CostAttributionLabel { get; set; }

    [JsonProperty("dashboard_query_labels")]
    [Display("Dashboard query labels")]
    public IEnumerable<string>? DashboardQueryLabels { get; set; }

    [JsonProperty("events")] public IEnumerable<string>? Events { get; set; }

    [JsonProperty("callback_url")]
    [Display("Callback URL")]
    public string? CallbackUrl { get; set; }

    [JsonProperty("metadata")] public string? Metadata { get; set; }

    [JsonProperty("char_limit")]
    [Display("Char limit")]
    public int? CharLimit { get; set; }
    
    public TranslateRequest()
    {
    }

    public TranslateRequest(TranslateRequest requestData)
    {
        IdContent = requestData.IdContent;
        SourceLanguage = requestData.SourceLanguage;
        TargetLanguages = requestData.TargetLanguages;
        ServiceType = requestData.ServiceType;
        IdOrder = requestData.IdOrder;
        IdOrderGroup = requestData.IdOrderGroup;
        ContentType = requestData.ContentType;
        Context = requestData.Context;
        PurchaseOrder = requestData.PurchaseOrder;
        CostAttributionLabel = requestData.CostAttributionLabel;
        DashboardQueryLabels = requestData.DashboardQueryLabels;
        Events = requestData.Events;
        CallbackUrl = requestData.CallbackUrl;
        Metadata = requestData.Metadata;
        CharLimit = requestData.CharLimit;
    }
}