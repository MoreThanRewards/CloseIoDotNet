namespace CloseIoDotNet.Entities.Definitions.Opportunities
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Opportunity
    {
        #region Instance Variables
        private IEnumerable<dynamic> _integrationLinks;
        #endregion

        #region Properties
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "confidence", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Confidence { get; set; }

        [JsonProperty(PropertyName = "contact_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactId { get; set; }

        [JsonProperty(PropertyName = "contact_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactName { get; set; }

        [JsonProperty(PropertyName = "created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "created_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedByName { get; set; }

        [JsonProperty(PropertyName = "date_created", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateCreated { get; set; }

        [JsonProperty(PropertyName = "date_lost", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateLost { get; set; }

        [JsonProperty(PropertyName = "date_updated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateUpdated { get; set; }

        [JsonProperty(PropertyName = "date_on", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateWon { get; set; }

        [JsonProperty(PropertyName = "integration_links", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<dynamic> IntegrationLinks
        {
            get { return _integrationLinks ?? (_integrationLinks = new List<dynamic>()); }
            set { _integrationLinks = value; }
        }

        [JsonProperty(PropertyName = "lead_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LeadId { get; set; }

        [JsonProperty(PropertyName = "lead_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LeadName { get; set; }

        [JsonProperty(PropertyName = "note", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Note { get; set; }

        [JsonProperty(PropertyName = "organization_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [JsonProperty(PropertyName = "status_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StatusId { get; set; }

        [JsonProperty(PropertyName = "status_label", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StatusLabel { get; set; }

        [JsonProperty(PropertyName = "status_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StatusType { get; set; }

        [JsonProperty(PropertyName = "updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "updated_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedByName { get; set; }

        [JsonProperty(PropertyName = "user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "user_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "value", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "value_currency", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ValueCurrency { get; set; }

        [JsonProperty(PropertyName = "value_formatted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ValueFormatted { get; set; }

        [JsonProperty(PropertyName = "value_period", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ValuePeriod { get; set; }
        #endregion
    }
}