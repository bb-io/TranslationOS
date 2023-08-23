using Blackbird.Applications.Sdk.Common;

namespace Apps.TranslationOS.Models.Request.TranslationManagement;

public class CancelTranslationInput
{
    [Display("Request ID")]
    public string Id { get; set; }
}