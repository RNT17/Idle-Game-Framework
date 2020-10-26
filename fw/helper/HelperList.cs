using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class HelperList
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("helpers")]
    public Dictionary<string, Helper> Helpers { get; set; }
}