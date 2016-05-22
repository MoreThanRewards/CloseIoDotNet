namespace CloseIoDotNet.Rest.MetaEntities
{
    using Newtonsoft.Json;

    public class StatusResponse
    {
         [JsonProperty(PropertyName = "status")]
         public string Status { get; set; }
    }
}