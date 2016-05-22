namespace CloseIoDotNet.Rest.Entities.Responses
{
    using Newtonsoft.Json;

    public class ErrorResponse
    {
        [JsonProperty(PropertyName = "error", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Error { get; set; }
    }
}