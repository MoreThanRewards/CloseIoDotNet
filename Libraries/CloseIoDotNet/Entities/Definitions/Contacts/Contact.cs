namespace CloseIoDotNet.Entities.Definitions.Contacts
{
    using System;
    using System.Collections.Generic;
    using Emails;
    using Fields.Contacts;
    using Newtonsoft.Json;
    using Phones;
    using Urls;

    public class Contact : AEntity<Contact>
    {
        #region Instance Variables
        private IEnumerable<Email> _emails;
        private IEnumerable<dynamic> _integrationLinks;
        private IEnumerable<Phone> _phones;
        private IEnumerable<Url> _urls;
        #endregion

        #region Properties
        [ContactEntityField(name: "Id", serializedName: "id", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }


        [ContactEntityField(name: "CreatedBy", serializedName: "created_by_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "created_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [ContactEntityField(name: "Emails", serializedName: "emails", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "emails", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Email> Emails
        {
            get { return _emails ?? (_emails = new List<Email>()); }
            set { _emails = value; }
        } 

        [ContactEntityField(name: "Name", serializedName: "name", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [ContactEntityField(name: "DateCreated", serializedName: "date_created", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_created", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateCreated { get; set; }

        [ContactEntityField(name: "DateUpdated", serializedName: "date_updated", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_updated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateUpdated { get; set; }

        [ContactEntityField(name: "IntegrationLinks", serializedName: "integration_links", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "integration_links", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<dynamic> IntegrationLinks
        {
            get { return _integrationLinks ?? (_integrationLinks = new List<dynamic>()); }
            set { _integrationLinks = value; }
        }

        [ContactEntityField(name: "OrganizationId", serializedName: "organization_id", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "organization_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [ContactEntityField(name: "Phones", serializedName: "phones", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "phones", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Phone> Phones
        {
            get { return _phones ?? (_phones = new List<Phone>()); }
            set { _phones = value; }
        }

        [ContactEntityField(name: "Title", serializedName: "title", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; set; }

        [ContactEntityField(name: "UpdatedBy", serializedName: "updated_by", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [ContactEntityField(name: "Urls", serializedName: "urls", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "urls", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Url> Urls
        {
            get { return _urls ?? (_urls = new List<Url>()); }
            set { _urls = value; }
        }
        #endregion
    }
}