namespace CloseIoDotNet.Rest.Entities.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Fields;
    using CloseIoDotNet.Ioc;
    using CloseIoDotNet.Rest.Utilities;
    using RequestFactories;
    using RestSharp;

    public class QueryRequest<T> : IQueryRequest<T> where T : IEntityQueryable, new()
    {
        #region Constants
        private const string QueryKeyFields = "_fields";
        #endregion

        #region Instance Variables
        private IEnumerable<IEntityField> _fields;
        #endregion

        #region Properties - Interface
        public string Id { get; set; }
        public IEnumerable<IEntityField> Fields
        {
            get { return _fields ?? (_fields = new List<IEntityField>()); }
            set { _fields = value; }
        }
        #endregion

        #region Properties
        private static IFieldsParameterValueFactory FieldParameterValueFactory
            => Factory.Create<IFieldsParameterValueFactory, FieldsParameterValueFactory>();
        #endregion

        #region Methods - Interface
        public IRestRequest CreateRestRequest(IRestRequestFactory restRequestFactory)
        {
            if (restRequestFactory == null)
            {
                throw new ArgumentNullException(nameof(restRequestFactory));
            }

            var result = CreateRestRequest(restRequestFactory, Id, Fields);

            return result;
        }
        #endregion

        #region Methods
        private static IRestRequest CreateRestRequest(IRestRequestFactory restRequestFactory, string id, IEnumerable<IEntityField> fields)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is required and cannot be null or empty.");
            }

            var result = restRequestFactory.Create((new T()).GenerateQueryResource(id), Method.GET);
            if (fields != null && fields.Any() == true)
            {
                var fieldParamValue = GenerateFieldsValue(fields);
                result.AddQueryParameter(QueryKeyFields, fieldParamValue);
            }
            return result;
        }

        private static string GenerateFieldsValue(IEnumerable<IEntityField> fields)
        {
            return FieldParameterValueFactory.Create(fields);
        }
        #endregion
    }
}