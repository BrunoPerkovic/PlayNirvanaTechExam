using Newtonsoft.Json;

namespace PlayNirvanaTechExam.Dtos;

public class LocationRestriction
{
    [JsonProperty("circle")]
    public Circle Circle { get; set; }
}

public class Circle
{
    [JsonProperty("center")]
    public Center Center { get; set; }

    [JsonProperty("radius")]
    public double Radius { get; set; }
}

public class Center
{
    [JsonProperty("latitude")]
    public double Latitude { get; set; }

    [JsonProperty("longitude")]
    public double Longitude { get; set; }
}