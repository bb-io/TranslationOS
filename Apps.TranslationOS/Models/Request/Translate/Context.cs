using System.Text.Json.Serialization;

namespace Apps.TranslationOS.Models.Request.Translate;

public class Context
{
    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }
    
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }
    
    [JsonPropertyName("references")]
    public string? References { get; set; }
    
    [JsonPropertyName("screenshot")]
    public string? Screenshot { get; set; }
    
    [JsonPropertyName("styleguide")]
    public string? Styleguide { get; set; }
}