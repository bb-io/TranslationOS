using Apps.TranslationOS.Constants;
using Apps.TranslationOS.Models.Request;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.TranslationOS.RestSharp;

public class TranslationOsClient : RestClient
{
    public TranslationOsClient() : base(new RestClientOptions
    {
        BaseUrl = new(ApiEndpoints.ApiUrl),
    })
    {
    }

    public async Task<T> ExecuteWithHandling<T>(TranslationOsRequest request)
    {
        var response = await ExecuteAsync(request);

        if (!response.IsSuccessStatusCode)
            throw ConfigureErrorException(response);

        return JsonConvert.DeserializeObject<T>(response.Content);
    }

    private Exception ConfigureErrorException(RestResponse response)
    {
        var error = JsonConvert.DeserializeObject<Error>(response.Content);

        throw new($"{error.Message}; Code: {error.Code}");
    }
}