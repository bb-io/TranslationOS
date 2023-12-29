using Apps.TranslationOS.Constants;
using Apps.TranslationOS.Models.Request.Translate;
using Apps.TranslationOS.Models.Request.TranslationManagement;
using Apps.TranslationOS.Models.Response;
using Apps.TranslationOS.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using RestSharp;
using System.Text;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;

namespace Apps.TranslationOS.Actions;

[ActionList]
public class TranslateActions : BaseInvocable
{
    #region Fields

    private readonly TranslationOsClient _client;
    private readonly IFileManagementClient _fileManagementClient;

    private IEnumerable<AuthenticationCredentialsProvider> Creds =>
        InvocationContext.AuthenticationCredentialsProviders;
    
    private string BridgeServiceUrl => $"{InvocationContext.UriInfo.BridgeServiceUrl}/webhooks/translationOS";

    #endregion

    #region Constructors

    public TranslateActions(InvocationContext context, IFileManagementClient fileManagementClient) : base(context)
    {
        _client = new();
        _fileManagementClient = fileManagementClient;
    }

    #endregion

    #region Actions

    [Action("Create text translation", Description = "Queue and process text translation")]
    public async Task<TranslateResponse> CreateTextTranslation(
        [ActionParameter] TranslateTextRequest requestData)
    {
        var request = new TranslationOsRequest(ApiEndpoints.Translate, Method.Post, Creds);
        var payload = new TranslateTextDto(requestData) { 
            CallbackUrl = requestData.CallbackUrl ?? QueryHelpers.AddQueryString(BridgeServiceUrl, "id", 
                GetApiKeyHash(InvocationContext.AuthenticationCredentialsProviders.First(p => p.KeyName == "apiKey").Value))
        };
        request.AddJsonBody(JsonConvert.SerializeObject(payload, new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        }));
        var response = await _client.ExecuteWithHandling<List<Translation>>(request);
        return new(response);
    }

    [Action("Create file translation", Description = "Queue and process file translation")]
    public async Task<TranslateResponse> CreateFileTranslation(
        [ActionParameter] TranslateFileRequest requestData)
    {
        var file = await _fileManagementClient.DownloadAsync(requestData.File);
        var bytes = await file.GetByteData();
            
        return await CreateTextTranslation(new(requestData)
        {
            Content = Encoding.UTF8.GetString(bytes)
        });
    }


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

    public static string GetApiKeyHash(string apiKey)
    {
        var crypt = new System.Security.Cryptography.SHA256Managed();
        var hash = new System.Text.StringBuilder();
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(apiKey));
        foreach (byte theByte in crypto)
        {
            hash.Append(theByte.ToString("x2"));
        }
        return hash.ToString();
    }
}