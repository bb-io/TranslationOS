using System.Net;
using Apps.TranslationOS.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Webhooks;

[WebhookList]
public class TranslateHooks
{
    [Webhook("On translation finished", Description = "On translation process finished")]
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
}