using Apps.TranslationOS.Actions;
using Apps.TranslationOS.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.TranslationOS.Webhooks.Handlers
{
    public class TranslationFinishedHandler : BaseInvocable, IWebhookEventHandler
    {
        private string TranslationId { get; set; }
        public TranslationFinishedHandler(InvocationContext invocationContext, [WebhookParameter] TranslationIdWebhookParameter input) : base(invocationContext)
        {
            TranslationId = input.Id;
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            await BridgeService.Subscribe(new BridgeRequest()
            {
                Url = values["payloadUrl"],
                Id = TranslateActions.GetApiKeyHash(InvocationContext.AuthenticationCredentialsProviders.First(p => p.KeyName == "apiKey").Value),
                Event = "translation"
            }, new BridgeCredentials() { Token = ApplicationConstants.BlackbirdToken, ServiceUrl = ApplicationConstants.BridgeServiceUrl });
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            await BridgeService.Unsubscribe(new BridgeRequest()
            {
                Url = values["payloadUrl"],
                Id = TranslateActions.GetApiKeyHash(InvocationContext.AuthenticationCredentialsProviders.First(p => p.KeyName == "apiKey").Value),
                Event = "translation"
            }, new BridgeCredentials() { Token = ApplicationConstants.BlackbirdToken, ServiceUrl = ApplicationConstants.BridgeServiceUrl });
        }
    }
}
