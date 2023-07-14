using System.Text.Json;
using System.Text.Json.Serialization;
using Apps.TranslationOS.Constants;
using Apps.TranslationOS.Models.Request.Translate;
using Apps.TranslationOS.Models.Request.TranslationManagement;
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
        var request = new TranslationOsRequest(ApiEndpoints.Translate, Method.Post, creds);
        request.AddJsonBody(JsonSerializer.Serialize(requestData, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        }));

        var response = await _client.ExecuteWithHandling<List<Translation>>(request);

        return new(response);
    }

    [Action("Create file translation", Description = "Queue and process file translation")]
    public Task<TranslateResponse> CreateFileTranslation(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] TranslateFileRequest requestData)
        => CreateTextTranslation(creds, new(requestData));


    [Action("Cancel translation", Description = "Cancel translation request")]
    public Task<CancelTranslationResponse> CancelTranslation(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] CancelTranslationRequest requestData)
    {
        var request = new TranslationOsRequest(ApiEndpoints.Cancel, Method.Post, creds);
        request.AddJsonBody(requestData);

        return _client.ExecuteWithHandling<CancelTranslationResponse>(request);
    }

    [Action("Update translation", Description = "Update translation request")]
    public async Task<TranslateResponse> UpdateTranslation(IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] UpdateTranslationRequest requestData)
    {
        var request = new TranslationOsRequest(ApiEndpoints.Update, Method.Post, creds);
        request.AddJsonBody(JsonSerializer.Serialize(requestData, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        }));

        var response = await _client.ExecuteWithHandling<List<Translation>>(request);

        return new(response);
    }

    #endregion
}