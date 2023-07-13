using Blackbird.Applications.Sdk.Common;

namespace Apps.TranslationOS;

public class TranslationOSApplication
{
    public class WordpressApplication : IApplication
    {
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
}