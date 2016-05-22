namespace CloseIoDotNet.Rest.Entities.Responses
{
    using Newtonsoft.Json;

    public class StatusResponse
    {
         [JsonProperty(PropertyName = "status")]
         public string Status { get; set; }
    }
}