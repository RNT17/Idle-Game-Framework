using System;
using Newtonsoft.Json;

public class Wrapper
{
    [JsonProperty("JsonValues")]
    public HelperList HelperList { get; set; }
}