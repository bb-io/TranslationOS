using Apps.TranslationOS.Models.Request.Translate.Base;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.TranslationOS.Models.Request.Translate;

public class TranslateFileRequest : TranslateRequest
{
    public FileReference File { get; set; }
}