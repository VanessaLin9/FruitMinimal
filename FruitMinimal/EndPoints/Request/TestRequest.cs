using Newtonsoft.Json;

namespace FruitMinial.EndPoints.Request;

public class TestRequest
{
    [JsonProperty("q1")]
    public string Q1 { get; set; }
    [JsonProperty("q2")]
    public string Q2 { get; set; }
}