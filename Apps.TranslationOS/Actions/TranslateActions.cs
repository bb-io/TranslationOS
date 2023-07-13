using Apps.TranslationOS.Constants;
using Apps.TranslationOS.Models.Request.Translate;
using Apps.TranslationOS.Models.Response;
using Apps.TranslationOS.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.TranslationOS.Actions;

[ActionList]
public class TranslateActions
{
    #region Fields

    private readonly TranslationOsClient _client;

    #endregion

    #region Constructors

    public TranslateActions()
    {
        _client = new();
    }

    #endregion

    #region Actions

    [Action("Create text translation", Description = "Queue and process text translation")]
    public async Task<TranslateResponse> CreateTextTranslation(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] TranslateTextRequest requestData)
    {
        var request = new TranslationOsRequest(ApiEndpoints.Translate, Method.Get, creds);
        request.AddJsonBody(requestData);

        var response = await _client.ExecuteWithHandling<List<Translation>>(request);

        return new(response);
    }

    [Action("Create file translation", Description = "Queue and process file translation")]
    public Task<TranslateResponse> CreateFileTranslation(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] TranslateFileRequest requestData)
        => CreateTextTranslation(creds, new(requestData));

    #endregion
}