using Newtonsoft.Json;

namespace PlayNirvanaTechExam.Dtos;

public class BaseRequest
{
    [JsonProperty("locationRestriction")]
    public LocationRestriction LocationRestriction { get; set; }
    [JsonProperty("includedTypes")]
    public List<string>? IncludedTypes { get; set; }
    [JsonProperty("excludedTypes")]
    public List<string>? ExcludedTypes { get; set; }
    [JsonProperty("includedPrimaryTypes")]
    public List<string>? IncludedPrimaryTypes { get; set; }
    [JsonProperty("excludedPrimaryTypes")]
    public List<string>? ExcludedPrimaryTypes { get; set; }
    [JsonProperty("languageCode")]
    public string? LanguageCode { get; set; }
    [JsonProperty("maxResultCount")]
    public double? MaxResultCount { get; set; }
    [JsonProperty("rankPreference")]
    public string? RankPreference { get; set; }
}