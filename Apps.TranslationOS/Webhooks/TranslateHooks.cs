using System.Net;
using System.Text.Json;
using Apps.TranslationOS.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.TranslationOS.Webhooks;

[WebhookList]
public class TranslateHooks
{
    [Webhook("On translation finished", Description = "On translation proccess finished")]
    public Task<WebhookResponse<TranslationFinished>> TranslationFinished(WebhookRequest webhookRequest)
    {
        var payload = JsonSerializer.Deserialize<List<TranslationFinished>>(webhookRequest.Body.ToString());

        if (payload == null || !payload.Any())
            throw new Exception("No serializable payload was found in inocming request.");

        return Task.FromResult(new WebhookResponse<TranslationFinished>
        {
            HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
            Result = payload.First()
        });
    }
}