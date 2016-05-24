namespace CloseIoDotNet.Rest.Serialization
{
    using System.IO;
    using Newtonsoft.Json;
    using RestSharp.Serializers;

    public class NewtonsoftSerializer : ISerializer
    {
        #region Instance Variables
        private readonly Newtonsoft.Json.JsonSerializer _serializer;
        #endregion

        #region Properties - Interface
        public string ContentType { get; set; }
        public string DateFormat { get; set; }
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        #endregion

        #region Constructors
        public NewtonsoftSerializer()
        {
            ContentType = "application/json";
            _serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }

        public NewtonsoftSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            ContentType = "application/json";
            _serializer = serializer;
        }
        #endregion

        #region Methods - Interface
        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.None;
                    jsonTextWriter.QuoteChar = '"';

                    _serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }
        #endregion


    }
}