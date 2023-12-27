using System.Text;
using Apps.TranslationOS.Models.Request.Translate.Base;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Newtonsoft.Json;

namespace Apps.TranslationOS.Models.Request.Translate;

public class TranslateTextRequest : TranslateRequest
{
    [JsonProperty("content")] public string Content { get; set; }

    private readonly IFileManagementClient _fileManagementClient;

    public TranslateTextRequest(IFileManagementClient fileManagementClient)
    {
        _fileManagementClient = fileManagementClient;
    }

    public TranslateTextRequest(TranslateFileRequest requestData) : base(requestData)
    {
        var fileBytes = _fileManagementClient.DownloadAsync(requestData.File).Result.GetByteData().Result;
        Content = Encoding.UTF8.GetString(fileBytes);
    }
}