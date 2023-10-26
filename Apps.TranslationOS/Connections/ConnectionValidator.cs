using Apps.TranslationOS.Constants;
using Apps.TranslationOS.Models.Request.Translate;
using Apps.TranslationOS.Models.Response;
using Apps.TranslationOS.RestSharp;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using Blackbird.Applications.Sdk.Common.Invocation;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.TranslationOS.Connections;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
    {
        var client = new TranslationOsClient();
        var request = new TranslationOsRequest(ApiEndpoints.Translate, Method.Post, authProviders);
        var payload = new
        {
            id_content = Guid.NewGuid(),
            content = "Connection validator test",
            source_language = "en-US",
            target_languages = new[] { "en-GB" },
            service_type = "premium"
        };
        request.AddJsonBody(JsonConvert.SerializeObject(payload));

        try
        {
            await client.ExecuteWithHandling<List<Translation>>(request);
            return new()
            {
                IsValid = true
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                IsValid = false,
                Message = ex.Message
            };
        }
    }
}