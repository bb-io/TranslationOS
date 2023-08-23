using Newtonsoft.Json;

namespace Apps.TranslationOS.Models.Request.Translate;

public class Context
{
    [JsonProperty("instructions")]
    public string? Instructions { get; set; }
    
    [JsonProperty("notes")]
    public string? Notes { get; set; }
    
    [JsonProperty("references")]
    public string? References { get; set; }
    
    [JsonProperty("screenshot")]
    public string? Screenshot { get; set; }
    
    [JsonProperty("styleguide")]
    public string? Styleguide { get; set; }
}