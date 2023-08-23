namespace Apps.TranslationOS.Constants;

public static class ApiEndpoints
{
    public const string ApiUrl = "https://api-sandbox.translated.com/v2";
    
    public const string Translate = "/translate";
    public const string Cancel = Translate + "/cancel";
    public const string Update = "/update";
    public const string Languages = "/symbol/languages";
    public const string ContentTypes = "/symbol/content-types";
}