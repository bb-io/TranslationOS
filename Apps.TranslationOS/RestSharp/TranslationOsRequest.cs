using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.TranslationOS.RestSharp;

public class TranslationOsRequest : RestRequest
{
    public TranslationOsRequest(string endpoint, Method method, IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders) : base(endpoint, method)
    {
        var token = authenticationCredentialsProviders.First(p => p.KeyName == "apiKey").Value;
        this.AddHeader("x-api-key", $"{token}");
    }
}