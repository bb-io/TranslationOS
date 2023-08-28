using Apps.TranslationOS.Models.Request.Translate.Base;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.TranslationOS.Models.Request.Translate;

public class TranslateFileRequest : TranslateRequest
{
    public File File { get; set; }
}