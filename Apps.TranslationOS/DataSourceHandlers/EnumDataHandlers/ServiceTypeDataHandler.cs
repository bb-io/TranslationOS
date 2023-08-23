using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.TranslationOS.DataSourceHandlers.EnumDataHandlers;

public class ServiceTypeDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        {"premium", "Premium"},
        {"professional", "Professional"},
        {"economy", "Economy"},
    };
}