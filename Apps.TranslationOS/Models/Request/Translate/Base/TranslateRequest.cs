using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.TranslationOS.Models.Request.Translate.Base;

public class TranslateRequest
{
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

    [JsonPropertyName("id_content")]
    [Display("Id content")]
    public string IdContent { get; set; }
    
    [JsonPropertyName("source_language")]
    [Display("Source language")]
    public string SourceLanguage { get; set; }
    
    [JsonPropertyName("target_languages")]
    [Display("Target languages")]
    public IEnumerable<string> TargetLanguages { get; set; }
    
    [JsonPropertyName("service_type")]
    [Display("Service type")]
    public string ServiceType { get; set; }
    
    [JsonPropertyName("id_order")]
    [Display("Id order")]
    public string? IdOrder { get; set; }
    
    [JsonPropertyName("id_order_group")]
    [Display("Id order group")]
    public string? IdOrderGroup { get; set; }
    
    [JsonPropertyName("content_type")]
    [Display("Content type")]
    public string? ContentType { get; set; }
    
    [JsonPropertyName("context")]
    [Display("Content")]
    public Context? Context { get; set; }
    
    [JsonPropertyName("purchase_order")]
    [Display("Purchase order")]
    public string? PurchaseOrder { get; set; }
    
    [JsonPropertyName("cost_attribution_label")]
    [Display("Cost attribution label")]
    public string? CostAttributionLabel { get; set; }
    
    [JsonPropertyName("dashboard_query_labels")]
    [Display("Dashboard query labels")]
    public IEnumerable<string>? DashboardQueryLabels { get; set; }
    
    [JsonPropertyName("events")]
    public IEnumerable<string>? Events { get; set; }
    
    [JsonPropertyName("callback_url")]
    [Display("Callback url")]
    public string? CallbackUrl { get; set; }
    
    [JsonPropertyName("metadata")]
    public string? Metadata { get; set; }
    
    [JsonPropertyName("char_limit")]
    [Display("Char limit")]
    public int? CharLimit { get; set; }
}