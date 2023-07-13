using System.Text.Json;
using Apps.TranslationOS.Models.Request;
using RestSharp;

namespace Apps.TranslationOS.RestSharp;

public class TranslationOsClient : RestClient
{
    public TranslationOsClient() : base(new RestClientOptions { BaseUrl = new Uri("https://api-sandbox.translated.com/v2") })
    {
    }

    public async Task<T> ExecuteWithHandling<T>(TranslationOsRequest request)
    {
        var response = await this.ExecuteAsync<T>(request);

        if (response.IsSuccessStatusCode)
            return response.Data;

        throw ConfigureErrorException(response);
    }

    private Exception ConfigureErrorException(RestResponse response)
    {
        var error = JsonSerializer.Deserialize<Error>(response.Content);

        throw new($"{error.Message}; Code: {error.Code}");
    }
}