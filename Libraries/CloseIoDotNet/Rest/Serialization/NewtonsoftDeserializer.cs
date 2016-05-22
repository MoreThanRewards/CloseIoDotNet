namespace CloseIoDotNet.Rest.Serialization
{
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Deserializers;

    public class NewtonsoftDeserializer : IDeserializer
    {
        public T Deserialize<T>(IRestResponse response)
        {
            var result = JsonConvert.DeserializeObject<T>(response.Content);
            return result;
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

    }
}