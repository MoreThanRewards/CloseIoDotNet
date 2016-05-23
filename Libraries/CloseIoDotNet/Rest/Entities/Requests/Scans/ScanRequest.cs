namespace CloseIoDotNet.Rest.Entities.Requests.Scans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Fields;
    using CloseIoDotNet.Rest.Entities.Responses;
    using RestSharp;

    public class ScanRequest<T> : ARequest<T>, IScanRequest<T> where T : IEntity, IEntityScannable, new()
    {
        #region Properties - Interface
        public IEnumerable<IEntityField> Fields { get; set; }
        #endregion

        #region Constructors
        public ScanRequest() { } 
        public ScanRequest(string apiKey) : base(apiKey) { }
        public ScanRequest(string apiKey, IRestClient restClient) : base(apiKey, restClient) { }
        #endregion

        #region Methods - Interface
        public IRestRequest CreateBaseRestRequest(int skip, int limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentException("Limit must be greater than 0.", nameof(limit));
            }
            var request = RestRequestFactory.Create((new T().GenerateScanResource()), Method.GET);
            request.AddQueryParameter(QueryKeySkip, skip.ToString("F0"));
            request.AddQueryParameter(QueryKeyLimit, limit.ToString("F0"));
            if (Fields != null && Fields.Any() == true)
            {
                var fieldParamValue = FieldParameterValueFactory.Create(Fields);
                request.AddQueryParameter(QueryKeyFields, fieldParamValue);
            }

            return request;
        }

        public IScanResponse<T> ExecuteScanRestRequest(IRestRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var response = RestClient.Execute<ScanResponse<T>>(request);
            RestResponseValidator.Validate(request, response);
            return response.Data;
        }

        public new void Dispose()
        {
            base.Dispose();
            Fields = null;
        }
        #endregion
    }
}