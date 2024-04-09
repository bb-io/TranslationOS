using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.TranslationOS;

public class TranslationOSApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.LspPortal];
        set { }
    }
    
    public string Name
    {
        get => "TranslationOS";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}