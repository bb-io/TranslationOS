using Apps.TranslationOS.DataSourceHandlers.EnumDataHandlers;
using Apps.TranslationOS.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.TranslationOS.Models.Request.Translate
{
    public class TranslateTextDto
    {
        public TranslateTextDto(TranslateTextRequest input)
        {
            IdContent = input.IdContent;
            SourceLanguage = input.SourceLanguage;
            TargetLanguages = input.TargetLanguages;
            ServiceType = input.ServiceType;
            IdOrder = input.IdOrder;
            IdOrderGroup = input.IdOrderGroup;
            ContentType = input.ContentType;
            Context = input.Context;
            PurchaseOrder = input.PurchaseOrder;
            CostAttributionLabel = input.CostAttributionLabel;
            DashboardQueryLabels = input.DashboardQueryLabels;
            Metadata = input.Metadata;
            CharLimit = input.CharLimit;
        }

        [JsonProperty("id_content")]
        public string IdContent { get; set; }

        [JsonProperty("source_language")]
        public string SourceLanguage { get; set; }

        [JsonProperty("target_languages")]
        public IEnumerable<string> TargetLanguages { get; set; }

        [JsonProperty("service_type")]
        [DataSource(typeof(ServiceTypeDataHandler))]
        public string ServiceType { get; set; }

        [JsonProperty("id_order")]
        public string? IdOrder { get; set; }

        [JsonProperty("id_order_group")]
        public string? IdOrderGroup { get; set; }

        [JsonProperty("content_type")]
        [DataSource(typeof(ContentTypeDataHandler))]
        public string? ContentType { get; set; }

        [JsonProperty("context")]
        public Context? Context { get; set; }

        [JsonProperty("purchase_order")]
        public string? PurchaseOrder { get; set; }

        [JsonProperty("cost_attribution_label")]
        public string? CostAttributionLabel { get; set; }

        [JsonProperty("dashboard_query_labels")]
        public IEnumerable<string>? DashboardQueryLabels { get; set; }

        [JsonProperty("events")] public IEnumerable<string> Events => new List<string>() { "translation" };

        [JsonProperty("callback_url")]
        public string CallbackUrl => ApplicationConstants.BridgeServiceUrl;

        [JsonProperty("metadata")] public string? Metadata { get; set; }

        [JsonProperty("char_limit")]
        public int? CharLimit { get; set; }
    }
}
