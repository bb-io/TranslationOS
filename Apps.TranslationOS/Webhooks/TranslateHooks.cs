using System.Net;
using Apps.TranslationOS.Webhooks.Handlers;
using Apps.TranslationOS.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Webhooks;

[WebhookList]
public class TranslateHooks
{
    [Webhook("On translation finished", typeof(TranslationFinishedHandler), Description = "On translation process finished")]
    public Task<WebhookResponse<TranslationWebhookResponse>> TranslationFinished(WebhookRequest webhookRequest)
    {
        var payload = JsonConvert.DeserializeObject<List<TranslationPayload>>(webhookRequest.Body.ToString());

        if (payload == null || !payload.Any())
            throw new Exception("No serializable payload was found in inocming request.");

        return Task.FromResult(new WebhookResponse<TranslationWebhookResponse>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new(payload)
        });
    }

    [Webhook("On translation finished (manual)", Description = "On translation process finished")]
    public Task<WebhookResponse<TranslationWebhookResponse>> TranslationFinishedManual(WebhookRequest webhookRequest)
    {
        var payload = JsonConvert.DeserializeObject<List<TranslationPayload>>(webhookRequest.Body.ToString());

        if (payload == null || !payload.Any())
            throw new Exception("No serializable payload was found in inocming request.");

        return Task.FromResult(new WebhookResponse<TranslationWebhookResponse>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = new(payload)
        });
    }
}