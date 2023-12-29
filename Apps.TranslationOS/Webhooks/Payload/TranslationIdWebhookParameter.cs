using Blackbird.Applications.Sdk.Common;

namespace Apps.TranslationOS.Webhooks.Payload
{
    public class TranslationIdWebhookParameter
    {
        [Display("Translation request ID")]
        public string Id { get; set; }
    }
}
