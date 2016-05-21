namespace CloseIoDotNet.Entities.Definitions.Contacts.Emails
{
    using Newtonsoft.Json;

    public class Email : IEntity
    {
        #region Properties
        [JsonProperty(PropertyName = "email", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        #endregion
    }
}