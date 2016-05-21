namespace CloseIoDotNet.Entities.Definitions.Contacts
{
    using System;
    using System.Collections.Generic;
    using Emails;
    using Newtonsoft.Json;
    using Phones;
    using Urls;

    public class Contact : IEntity
    {
        #region Instance Variables
        private IEnumerable<Email> _emails;
        private IEnumerable<dynamic> _integrationLinks;
        private IEnumerable<Phone> _phones;
        private IEnumerable<Url> _urls;
        #endregion

        #region Properties
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }


        [JsonProperty(PropertyName = "created_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "emails", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Email> Emails
        {
            get { return _emails ?? (_emails = new List<Email>()); }
            set { _emails = value; }
        } 

        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "date_created", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateCreated { get; set; }

        [JsonProperty(PropertyName = "date_updated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateUpdated { get; set; }

        [JsonProperty(PropertyName = "integration_links", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<dynamic> IntegrationLinks
        {
            get { return _integrationLinks ?? (_integrationLinks = new List<dynamic>()); }
            set { _integrationLinks = value; }
        }

        [JsonProperty(PropertyName = "organization_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [JsonProperty(PropertyName = "phones", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Phone> Phones
        {
            get { return _phones ?? (_phones = new List<Phone>()); }
            set { _phones = value; }
        }

        [JsonProperty(PropertyName = "title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "urls", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Url> Urls
        {
            get { return _urls ?? (_urls = new List<Url>()); }
            set { _urls = value; }
        }
        #endregion
    }
}