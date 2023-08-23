using Apps.TranslationOS.Models.Request.Translate.Base;

namespace Apps.TranslationOS.Models.Request.Translate;

public class TranslateFileRequest : TranslateRequest
{
    public byte[] File { get; set; }
}