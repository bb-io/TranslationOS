using Apps.TranslationOS.Actions;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge.Models.Request;

namespace Apps.TranslationOS.Webhooks.Handlers
{
    public class TranslationFinishedHandler : BaseInvocable, IWebhookEventHandler
    {
        private string BridgeServiceUrl => $"{InvocationContext.UriInfo.BridgeServiceUrl}/webhooks/translationOS";

        public TranslationFinishedHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            await BridgeService.Subscribe(new BridgeRequest()
            {
                Url = values["payloadUrl"],
                Id = TranslateActions.GetApiKeyHash(InvocationContext.AuthenticationCredentialsProviders.First(p => p.KeyName == "apiKey").Value),
                Event = "translation"
            }, new BridgeCredentials() { Token = ApplicationConstants.BlackbirdToken, ServiceUrl = BridgeServiceUrl });
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            await BridgeService.Unsubscribe(new BridgeRequest()
            {
                Url = values["payloadUrl"],
                Id = TranslateActions.GetApiKeyHash(InvocationContext.AuthenticationCredentialsProviders.First(p => p.KeyName == "apiKey").Value),
                Event = "translation"
            }, new BridgeCredentials() { Token = ApplicationConstants.BlackbirdToken, ServiceUrl = BridgeServiceUrl });
        }
    }
}
