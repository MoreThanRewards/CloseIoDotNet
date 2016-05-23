namespace CloseIoDotNet.Rest.Entities.Requests.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Fields;
    using RestSharp;

    public class QueryRequest<T> : ARequest<T>, IQueryRequest<T> where T : IEntityQueryable, new()
    {
        #region Instance Variables
        private string _id;
        private IEnumerable<IEntityField> _fields;
        #endregion

        #region Properties - Interface
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(_id))
                {
                    throw new InvalidOperationException("Id not initialized.");
                }
                return _id;
            }
            set { _id = value; }
        }
        public IEnumerable<IEntityField> Fields
        {
            get { return _fields ?? (_fields = new List<IEntityField>()); }
            set { _fields = value; }
        }
        #endregion

        #region Methods - Interface
        public T Execute()
        {
            var request = RestRequestFactory.Create((new T()).GenerateQueryResource(Id), Method.GET);
            if (Fields != null && Fields.Any() == true)
            {
                var fieldParamValue = FieldParameterValueFactory.Create(Fields);
                request.AddQueryParameter(QueryKeyFields, fieldParamValue);
            }
            var response = RestClient.Execute<T>(request);
            RestResponseValidator.Validate(request, response);
            var result = response.Data;
            return result;
        }

        public new void Dispose()
        {
            base.Dispose();
            Id = null;
            Fields = null;
        }
        #endregion
    }
}