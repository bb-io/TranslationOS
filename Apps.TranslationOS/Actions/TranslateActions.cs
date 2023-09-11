using Apps.TranslationOS.Constants;
using Apps.TranslationOS.Models.Request.Translate;
using Apps.TranslationOS.Models.Request.TranslationManagement;
using Apps.TranslationOS.Models.Response;
using Apps.TranslationOS.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.TranslationOS.Actions;

[ActionList]
public class TranslateActions : BaseInvocable
{
    #region Fields

    private readonly TranslationOsClient _client;

    private IEnumerable<AuthenticationCredentialsProvider> Creds =>
        InvocationContext.AuthenticationCredentialsProviders;

    #endregion

    #region Constructors

    public TranslateActions(InvocationContext context) : base(context)
    {
        _client = new();
    }

    #endregion

    #region Actions

    [Action("Create text translation", Description = "Queue and process text translation")]
    public async Task<TranslateResponse> CreateTextTranslation(
        [ActionParameter] TranslateTextRequest requestData)
    {
        var request = new TranslationOsRequest(ApiEndpoints.Translate, Method.Post, Creds);
        request.AddJsonBody(JsonConvert.SerializeObject(new TranslateTextDto(requestData), new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        }));

        var response = await _client.ExecuteWithHandling<List<Translation>>(request);
        return new(response);
    }

    [Action("Create file translation", Description = "Queue and process file translation")]
    public Task<TranslateResponse> CreateFileTranslation(
        [ActionParameter] TranslateFileRequest requestData)
        => CreateTextTranslation(new(requestData));


    [Action("Cancel translation", Description = "Cancel translation request")]
    public Task<CancelTranslationResponse> CancelTranslation(
        [ActionParameter] CancelTranslationInput input)
    {
        var request = new TranslationOsRequest(ApiEndpoints.Cancel, Method.Post, Creds);
        request.AddJsonBody(new CancelTranslationRequest(input));

        return _client.ExecuteWithHandling<CancelTranslationResponse>(request);
    }

    [Action("Update translation", Description = "Update translation request")]
    public async Task<TranslateResponse> UpdateTranslation(
        [ActionParameter] UpdateTranslationRequest requestData)
    {
        var request = new TranslationOsRequest(ApiEndpoints.Update, Method.Post, Creds);
        request.AddJsonBody(JsonConvert.SerializeObject(requestData, new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        }));

        var response = await _client.ExecuteWithHandling<List<Translation>>(request);

        return new(response);
    }

    #endregion
}