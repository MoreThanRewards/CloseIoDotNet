
namespace CloseIoDotNet.Test
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Definitions.Contacts;
    using CloseIoDotNet.Entities.Definitions.Opportunities;
    using CloseIoDotNet.Entities.Definitions.Tasks;
    using CloseIoDotNet.Entities.Fields;
    using CloseIoDotNet.Ioc;

    [TestClass]
    public class CloseIoDotNetContextTest
    {
        #region Propeties
        private static string ApiKey => ConfigurationManager.AppSettings["CloseIoApiKey"];
        private static string QueryTestLeadId => ConfigurationManager.AppSettings["CloseIoQueryTestLeadId"];
        private static string QueryTestContactId => ConfigurationManager.AppSettings["CloseIoQueryTestContactId"];
        private static string QueryTestOpportunityId
            => ConfigurationManager.AppSettings["CloseIoQueryTestOpportunityId"];
        private static string QueryTestTaskId => ConfigurationManager.AppSettings["CloseIoQueryTestTaskId"];
        private static string ScanTestLeadId => ConfigurationManager.AppSettings["CloseIoScanTestLeadId"];
        private static string ScanTestContactId => ConfigurationManager.AppSettings["CloseIoScanTestContactId"];
        private static string ScanTestOpportunityId
            => ConfigurationManager.AppSettings["CloseIoScanTestOpportunityId"];
        private static string ScanTestTaskId => ConfigurationManager.AppSettings["CloseIoScanTestTaskId"];
        #endregion

        #region Query
        [TestMethod]
        public void TestIntegrationQueryLead()
        {
            var inputLeadId = QueryTestLeadId;
            var inputApiKey = ApiKey;
            using (var unit = Factory.Create<ICloseIoDotNetContext, CloseIoDotNetContext>(inputApiKey))
            {
                var result = unit.Query<Lead>(inputLeadId);
                Assert.IsNotNull(result);
                Assert.AreEqual(inputLeadId, result.Id);
                Assert.IsNotNull(result.Tasks);
                Assert.IsNotNull(result.Addresses);
                Assert.IsNotNull(result.Opportunities);
                Assert.IsNotNull(result.Contacts);

                Assert.AreEqual(1, result.Tasks.Count());
                Assert.AreEqual(4, result.Addresses.Count());
                Assert.AreEqual(4, result.Contacts.Count());
                Assert.AreEqual(3, result.Opportunities.Count());

                //lead level
                Assert.AreEqual("Jim Jones", result.DisplayName);
                Assert.AreEqual("user_K1WHnUaeXo6Kh5HbHkLTk7jG00VXmpqJzVtwrCpPTOP", result.UpdatedBy);
                Assert.AreEqual("stat_SDtZepLpf7pV3qHDogcXdr8Xui4YHIVmg2fpO9ML5nK", result.StatusId);
                Assert.AreEqual(new DateTime(2016,5,22,18,13,8, DateTimeKind.Utc).AddMilliseconds(682), result.DateUpdated.Value.ToUniversalTime());
                Assert.AreEqual("Customer", result.StatusLabel);
                Assert.AreEqual(string.Empty, result.Description);
                Assert.AreEqual("https://app.close.io/lead/lead_54ZcJyA95l9vbdRGHBoAN2zDAo9qVJ6gKwy9AoWxn6E/", result.HtmlUrl);
                Assert.AreEqual("user_EdKzcSRRzdthZmtdTMEzMTWBXk92nhpH40OZSAGC3Kw", result.CreatedBy);
                Assert.AreEqual("orga_9A2oIFReE6EbRh2NDYoz9cFiFp7ephrSlazMpQNwjxS", result.OrganizationId);
                Assert.AreEqual("http://www.jones.com", result.Url);
                Assert.AreEqual(new DateTime(2016,5,13,19,39,49, DateTimeKind.Utc).AddMilliseconds(399).ToUniversalTime(), result.DateCreated.Value.ToUniversalTime());
                Assert.AreEqual("Jacob Prather", result.CreatedByName);
                Assert.AreEqual("Customer Support", result.UpdatedByName);
                Assert.AreEqual("Jim Jones", result.Name);

                //custom fields 
                var customAssertion = new Dictionary<string, dynamic>()
                {
                    {"* Most Recent Invoice Amount:",421.34},
                    {"— Employees Total","0.0"},
                    {"— Total Computers","2 - 9 PCs"},
                    {"— Primary SIC Desc","Motorcycles & Motor Scooters-Dealers"},
                    {"* Most Recent Invoice #","0020008"},
                    {"— Secondary SIC","557106"},
                    {"— Credit Score Alpha","B"},
                    {"— Secondary SIC Desc","Motorcycles & Motor Scooters-Dealers"},
                    {"— Competitive Area","Columbia, TN"},
                    {"— Year Store Opened","0"},
                    {"— Yellow Page Spending Habits","Regular"},
                    {"— County Name","Maury"},
                    {"— Third SIC","594141"},
                    {"— Annual Income","0"},
                    {"Gender","FEMALE"},
                    {"* Franchise","No"},
                    {"— Third SIC Desc","Bicycles-Dealers"},
                    {"Franchise Status","Branch"},
                    {"— Employees Range","10 to 19"},
                    {"— Credit Score Numeric","0.0"},
                    {"— Import Type","HyperDrive"},
                    {"Annual_Sales_Volume","Branch"},
                    {"freshbooks_opportunity_map","{\"157\":{\"lost_opp_id\":\"oppo_mpFo12QjMOGCdMmMMjCkpsCc06cs8o6gKIQszM1bU7W\",\"lost_value\":1.00},\"152\":{\"lost_opp_id\":\"oppo_q7Xkatg1z9pVETEhC7UaPRe3XlbK0WQpbiKxqhCVXOy\"},\"400\":{\"won_opp_id\":\"oppo_954jFpzmaeIUcvbB5lnt0iwHlO2LPJDpJgvh6BU5uza\",\"won_value\":421.34}}"},
                    {"— Industry 2","Suzuki"},
                    {"— Industry 1","Harley Davidson"},
                    {"* Most Recent Invoice Date","2016-05-01"},
                    {"— Store Sq Footage","2,500 - 9,999"},
                    {"— Import Date","2016-03-20"},
                    {"— Primary SIC","557106"},
                    {"* Most Recent Invoice URL","http://widget.morethanrewards.com/zendesk/GetInvoicePdf?id=MDAwMDEyMjYwNjU="}
                };

                foreach (var kvp in customAssertion)
                {
                    var key = kvp.Key;
                    var value = kvp.Value;
                    Assert.IsTrue(result.Custom.ContainsKey(key));
                    Assert.AreEqual(value, result.Custom[key]);
                }

                //address level
                //first address
                var addr = result.Addresses.ToList()[0];
                Assert.AreEqual("Columbia", addr.City);
                Assert.AreEqual("US", addr.Country);
                Assert.AreEqual("38401-7771", addr.PostalZip);
                Assert.AreEqual("business", addr.Label);
                Assert.AreEqual("TN", addr.State);
                Assert.AreEqual("1616 Harley Davidson Blvd", addr.AddressLine1);
                Assert.AreEqual("", addr.AddressLine2);

                //second address
                addr = result.Addresses.ToList()[1];
                Assert.AreEqual("Tarentum", addr.City);
                Assert.AreEqual("US", addr.Country);
                Assert.AreEqual("15084-1507", addr.PostalZip);
                Assert.AreEqual("business", addr.Label);
                Assert.AreEqual("PA", addr.State);
                Assert.AreEqual("139 E 6th Ave", addr.AddressLine1);
                Assert.AreEqual("", addr.AddressLine2);

                //third address
                addr = result.Addresses.ToList()[2];
                Assert.AreEqual("", addr.City);
                Assert.AreEqual("US", addr.Country);
                Assert.AreEqual("", addr.PostalZip);
                Assert.AreEqual("business", addr.Label);
                Assert.AreEqual("", addr.State);
                Assert.AreEqual("", addr.AddressLine1);
                Assert.AreEqual("", addr.AddressLine2);

                //fourth address
                addr = result.Addresses.ToList()[3];
                Assert.AreEqual("New Rochelle", addr.City);
                Assert.AreEqual("US", addr.Country);
                Assert.AreEqual("", addr.PostalZip);
                Assert.AreEqual("business", addr.Label);
                Assert.AreEqual("NY", addr.State);
                Assert.AreEqual("", addr.AddressLine1);
                Assert.AreEqual("", addr.AddressLine2);
            }
        }

        [TestMethod]
        public void TestIntegrationQueryContact()
        {
            var inputContactId = QueryTestContactId;
            var inputApiKey = ApiKey;
            using (var unit = Factory.Create<ICloseIoDotNetContext, CloseIoDotNetContext>(inputApiKey))
            {
                var result = unit.Query<Contact>(inputContactId);
                Assert.IsNotNull(result);
                Assert.AreEqual(inputContactId, result.Id);
                Assert.AreEqual("Jim Jones", result.Name);
                Assert.AreEqual("", result.Title);
                Assert.AreEqual(new DateTime(2016,5,13,19,51,15, DateTimeKind.Utc).AddMilliseconds(600).ToUniversalTime(), result.DateUpdated.Value.ToUniversalTime());
                Assert.AreEqual("user_EdKzcSRRzdthZmtdTMEzMTWBXk92nhpH40OZSAGC3Kw", result.CreatedBy);
                Assert.AreEqual("orga_9A2oIFReE6EbRh2NDYoz9cFiFp7ephrSlazMpQNwjxS", result.OrganizationId);
                Assert.AreEqual(new DateTime(2016,5,13,19,51,15, DateTimeKind.Utc).AddMilliseconds(600).ToUniversalTime(), result.DateCreated.Value.ToUniversalTime());
                Assert.AreEqual("user_EdKzcSRRzdthZmtdTMEzMTWBXk92nhpH40OZSAGC3Kw", result.UpdatedBy);

                Assert.AreEqual(1, result.Phones.Count());
                Assert.AreEqual(0, result.Urls.Count());
                Assert.AreEqual(1, result.Emails.Count());

                var phone = result.Phones.First();
                Assert.AreEqual("+14144676624", phone.PhoneNumber);
                Assert.AreEqual("+1 414-467-6624", phone.PhoneNumberFormatted);
                Assert.AreEqual("office", phone.Type);

                var email = result.Emails.First();
                Assert.AreEqual("jim@jones.com", email.Address);
                Assert.AreEqual("office", email.Type);
            }
        }

        [TestMethod]
        public void TestIntegrationQueryOpportunity()
        {
            var inputOpportunityId = QueryTestOpportunityId;
            var inputApiKey = ApiKey;
            using (var unit = Factory.Create<ICloseIoDotNetContext, CloseIoDotNetContext>(inputApiKey))
            {
                var result = unit.Query<Opportunity>(inputOpportunityId);
                Assert.IsNotNull(result);
                Assert.AreEqual(inputOpportunityId, result.Id);

                Assert.AreEqual(new DateTime(2016,5,13,23,1,33,DateTimeKind.Utc).AddMilliseconds(108).ToUniversalTime(), result.DateUpdated.Value.ToUniversalTime());
                Assert.AreEqual("Jacob Prather", result.CreatedByName);
                Assert.AreEqual("USD", result.ValueCurrency);
                Assert.AreEqual(null, result.ContactId);
                Assert.AreEqual("Jim Jones", result.LeadName);
                Assert.AreEqual(null, result.ContactName);
                Assert.AreEqual(0, result.Confidence);
                Assert.AreEqual("user_EdKzcSRRzdthZmtdTMEzMTWBXk92nhpH40OZSAGC3Kw", result.UserId);
                Assert.AreEqual("monthly", result.ValuePeriod);
                Assert.AreEqual("user_EdKzcSRRzdthZmtdTMEzMTWBXk92nhpH40OZSAGC3Kw", result.CreatedBy);
                Assert.AreEqual("Freshbooks Client Id: 152\r\nFreshbooks Client Name: Jason's Test Dealer", result.Note);
                Assert.AreEqual("Jacob Prather", result.UpdatedByName);
                Assert.AreEqual("Jacob Prather", result.UserName);
                Assert.AreEqual("lost", result.StatusType);
                Assert.AreEqual("user_EdKzcSRRzdthZmtdTMEzMTWBXk92nhpH40OZSAGC3Kw", result.UpdatedBy);
                Assert.AreEqual("stat_cfdUxWvbxKJWw37tZ5OuoPEm5MSjilxSMbcOYnoK54x", result.StatusId);
                Assert.AreEqual("", result.ValueFormatted);
                Assert.AreEqual("orga_9A2oIFReE6EbRh2NDYoz9cFiFp7ephrSlazMpQNwjxS", result.OrganizationId);
                Assert.AreEqual(0, result.IntegrationLinks.Count());
                Assert.AreEqual(null, result.DateWon);
                Assert.AreEqual("lead_54ZcJyA95l9vbdRGHBoAN2zDAo9qVJ6gKwy9AoWxn6E", result.LeadId);
                Assert.AreEqual(new DateTime(2016,5,13,22,13,38, DateTimeKind.Utc).AddMilliseconds(127).ToUniversalTime(), result.DateLost.Value.ToUniversalTime());
                Assert.AreEqual(0, result.Value);
                Assert.AreEqual("Canceled : Confirmed", result.StatusLabel);
                Assert.AreEqual(new DateTime(2016,5,13,22,13,38, DateTimeKind.Utc).AddMilliseconds(127).ToUniversalTime(), result.DateCreated.Value.ToUniversalTime());
            }
        }

        [TestMethod]
        public void TestIntegrationQueryTasks()
        {
            var inputTaskId = QueryTestTaskId;
            var inputApiKey = ApiKey;
            using (var unit = new CloseIoDotNetContext(inputApiKey))
            {
                var result = unit.Query<Task>(inputTaskId);
                Assert.IsNotNull(result);
                Assert.AreEqual(inputTaskId, result.Id);

                Assert.AreEqual(new DateTime(2016,5,22,18,12,43, DateTimeKind.Utc).AddMilliseconds(570).ToUniversalTime(), result.DateUpdated.Value.ToUniversalTime());
                Assert.AreEqual("Follow up", result.Text);
                Assert.AreEqual(null, result.ObjectType);
                Assert.AreEqual(null, result.ContactId);
                Assert.AreEqual("user_K1WHnUaeXo6Kh5HbHkLTk7jG00VXmpqJzVtwrCpPTOP", result.CreatedBy);
                Assert.AreEqual("Jim Jones", result.LeadName);
                Assert.AreEqual(null, result.ContactName);
                Assert.AreEqual(null, result.ObjectId);
                Assert.AreEqual("Customer Support", result.UpdatedByName);
                Assert.AreEqual("Customer Support", result.CreatedByName);
                Assert.AreEqual(false, result.IsDateless);
                Assert.AreEqual(new DateTime(2016,5,22,16,30,0,DateTimeKind.Utc).ToUniversalTime(), result.DueDate.Value.ToUniversalTime());
                Assert.AreEqual("lead", result.Type);
                Assert.AreEqual("user_K1WHnUaeXo6Kh5HbHkLTk7jG00VXmpqJzVtwrCpPTOP", result.UpdatedBy);
                Assert.AreEqual("orga_9A2oIFReE6EbRh2NDYoz9cFiFp7ephrSlazMpQNwjxS", result.OrganizationId);
                Assert.AreEqual("Customer Support", result.AssignedToName);
                Assert.AreEqual(new DateTime(2016,5,22,16,30,0,DateTimeKind.Utc).ToUniversalTime(), result.Date.Value.ToUniversalTime());
                Assert.AreEqual("lead_54ZcJyA95l9vbdRGHBoAN2zDAo9qVJ6gKwy9AoWxn6E", result.LeadId);
                Assert.AreEqual("user_K1WHnUaeXo6Kh5HbHkLTk7jG00VXmpqJzVtwrCpPTOP", result.AssignedTo);
                Assert.AreEqual(new DateTime(2016,5,22,18,12,43,DateTimeKind.Utc).AddMilliseconds(570).ToUniversalTime(), result.DateCreated.Value.ToUniversalTime());
                Assert.AreEqual(false, result.IsComplete);
                Assert.AreEqual("inbox", result.View);
            }
        }
        #endregion

        #region Scan
        [TestMethod]
        public void TestIntegrationLeadScan()
        {
            var inputApiKey = ApiKey;
            using (var unit = Factory.Create<ICloseIoDotNetContext, CloseIoDotNetContext>(inputApiKey))
            {
                var result = unit.Scan<Lead>();
                Assert.AreEqual(14745, result.Count());
                Assert.IsNotNull(result.Single(entry => string.Equals(ScanTestLeadId, entry.Id)));
            }
        }

        [TestMethod]
        public void TestIntegrationContactScan()
        {
            var inputApiKey = ApiKey;
            using (var unit = Factory.Create<ICloseIoDotNetContext, CloseIoDotNetContext>(inputApiKey))
            {
                var result = unit.Scan<Contact>();
                Assert.IsTrue(result.Count() > 100);
                Assert.IsNotNull(result.Single(entry => string.Equals(ScanTestContactId, entry.Id)));
            }
        }

        [TestMethod]
        public void TestIntegrationOpportunityScan()
        {
            var inputApiKey = ApiKey;
            using (var unit = Factory.Create<ICloseIoDotNetContext, CloseIoDotNetContext>(inputApiKey))
            {
                var result = unit.Scan<Opportunity>();
                Assert.AreEqual(406, result.Count());
                Assert.IsNotNull(result.Single(entry => string.Equals(ScanTestOpportunityId, entry.Id)));
            }
        }

        [TestMethod]
        public void TestIntegrationTaskScan()
        {
            var inputApiKey = ApiKey;
            using (var unit = Factory.Create<ICloseIoDotNetContext, CloseIoDotNetContext>(inputApiKey))
            {
                var result = unit.Scan<Task>();
                Assert.AreEqual(1, result.Count());
                Assert.IsNotNull(result.Single(entry => string.Equals(ScanTestTaskId, entry.Id)));
                ;
            }
        }

        [TestMethod]
        public void TestIntegrationLeadScanWithFieldsAndQuery()
        {
            var inputApiKey = ApiKey;
            var inputSearchQuery = "email_address:jim@jones.com";
            var inputFields = new List<IEntityField>
            {
                (new Lead()).EntityFields.First(entry => entry.SerializedName.Equals("id")),
                (new Lead()).EntityFields.First(entry => entry.SerializedName.Equals("contacts"))
            };
            using (var unit = Factory.Create<ICloseIoDotNetContext, CloseIoDotNetContext>(inputApiKey))
            {
                var result = unit.Scan<Lead>(inputSearchQuery, inputFields);
                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Count());
                Assert.AreEqual(ScanTestLeadId, result.First().Id);
                Assert.AreEqual(ScanTestContactId, result.First().Contacts.First().Id);
                Assert.IsFalse(result.First().Addresses.Any());
                Assert.IsFalse(result.First().Opportunities.Any());
            }
        }
        #endregion

        #region README examples

        [TestMethod]
        public void TestIntegrationReadmeScanWithQueryExample()
        {
            using (var context = new CloseIoDotNetContext(ApiKey))
            {
                var fieldsToSearch = (new Lead()).EntityFields.Where(entry => entry.SerializedName.Equals("contacts"));
                var searchQuery = "phone_number:414-326-4100";
                var result = context.Scan<Lead>(searchQuery, fieldsToSearch).SelectMany(entry => entry.Contacts).Select(entry => entry.Name);
                Assert.IsTrue(result.Contains("Brandon Sigesmund"));
            }
        }
        #endregion
    }
}
