namespace CloseIoDotNet.Entities.Definitions
{
    using System;
    using System.Collections.Generic;
    using Addresses;
    using Contacts;
    using Newtonsoft.Json;
    using Opportunities;
    using Tasks;

    public class Lead
    {
        #region Instance Variables
        private IEnumerable<Address> _addresses;
        private IEnumerable<Contact> _contacts;
        private IDictionary<string, dynamic> _custom;
        private IEnumerable<dynamic> _integrationLinks;
        private IEnumerable<Opportunity> _opportunities;
        private IEnumerable<Task> _tasks;
        #endregion

        #region Properties
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "addresses", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Address> Addresses
        {
            get { return _addresses ?? (_addresses = new List<Address>()); }
            set { _addresses = value; }
        }

        [JsonProperty(PropertyName = "contacts", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Contact> Contacts
        {
            get { return _contacts ?? (_contacts = new List<Contact>()); }
            set { _contacts = value; }
        }

        [JsonProperty(PropertyName = "created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "created_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedByName { get; set; }

        [JsonProperty(PropertyName = "custom", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IDictionary<string, dynamic> Custom
        {
            get { return _custom ?? (_custom = new Dictionary<string, dynamic>()); }
            set { _custom = value; }
        }

        [JsonProperty(PropertyName = "date_created", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateCreated { get; set; }

        [JsonProperty(PropertyName = "date_updated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateUpdated { get; set; }

        [JsonProperty(PropertyName = "display_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "html_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string HtmlUrl { get; set; }

        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "integration_links", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<dynamic> IntegrationLinks //TODO figure out how to tackle these, if at all.
        {
            get { return _integrationLinks ?? (_integrationLinks = new List<dynamic>()); }
            set { _integrationLinks = value; }
        }

        [JsonProperty(PropertyName = "opportunities", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Opportunity> Opportunities
        {
            get { return _opportunities ?? (_opportunities = new List<Opportunity>()); }
            set { _opportunities = value; }
        }

        [JsonProperty(PropertyName = "organization_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [JsonProperty(PropertyName = "status_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StatusId { get; set; }

        [JsonProperty(PropertyName = "status_label", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StatusLabel { get; set; }

        [JsonProperty(PropertyName = "tasks", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Task> Tasks
        {
            get { return _tasks ?? (_tasks = new List<Task>()); }
            set { _tasks = value; }
        }

        [JsonProperty(PropertyName = "url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "updated_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedByName { get; set; }
        #endregion
    }
}