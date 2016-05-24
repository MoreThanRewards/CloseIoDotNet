namespace CloseIoDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CloseIoDotNet.Entities.Enumerations;
    using CloseIoDotNet.Rest.Entities.Requests.Queries;
    using CloseIoDotNet.Rest.Entities.Requests.Scans;
    using CloseIoDotNet.Rest.Entities.Responses.Enumerables;
    using Entities.Definitions;
    using Entities.Fields;
    using Ioc;

    public class CloseIoDotNetContext : ICloseIoDotNetContext
    {
        #region Instance Variables
        private string _apiKey;
        #endregion

        #region Properties
        public string ApiKey
        {
            private get
            {
                if (string.IsNullOrEmpty(_apiKey))
                {
                    throw new InvalidOperationException("ApiKey not initialized.");
                }
                return _apiKey;
            }
            set { _apiKey = value; }
        }
        #endregion

        #region Constructors
        public CloseIoDotNetContext() { }
        public CloseIoDotNetContext(string apiKey)
        {
            ApiKey = apiKey;
        }
        #endregion

        #region Methods - Interface
        public void Dispose()
        {
            ApiKey = null;
        }


        public T Query<T>(string id) where T : IEntityQueryable, new()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is required and cannot be null or empty.");
            }

            using (var request = Factory.Create<IQueryRequest<T>, QueryRequest<T>>())
            {
                request.ApiKey = ApiKey;
                request.Id = id;
                var result = request.Execute();
                return result;
            }
        }

        public T Query<T>(string id, IEnumerable<IEntityField> fields) where T : IEntityQueryable, new()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is required and cannot be null or empty.");
            }

            if (fields.Any() == false)
            {
                throw new ArgumentException("fields must contain at least one field to retrieve", nameof(fields));
            }

            if (fields.Any(entry => entry.BelongsTo != typeof (T)))
            {
                throw new ArgumentException("All fields must be a member of the entity being scanned.", nameof(fields));
            }

            using (var request = Factory.Create<IQueryRequest<T>, QueryRequest<T>>())
            {
                request.ApiKey = ApiKey;
                request.Id = id;
                request.Fields = fields;
                var result = request.Execute();
                return result;
            }
        }

        public IEnumerable<T> Scan<T>() where T : IEntityScannable, new()
        {
            if (ValidateScanTypeSupported<T>(ScanType.Base) == false)
            {
                throw new InvalidOperationException($"Entity of type {typeof (T).Name} does not support this type of scan.");
            }

            var scanRequest = Factory.Create<IScanRequest<T>, ScanRequest<T>>();
            scanRequest.ApiKey = ApiKey;

            var result = new ScanEnumerable<T>(scanRequest);
            return result;
        }

        public IEnumerable<T> Scan<T>(string searchQuery) where T : IEntityScannable, new()
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                throw new ArgumentException("searchQuery cannot be null, empty, or whitespace.", nameof(searchQuery));
            }

            if (ValidateScanTypeSupported<T>(ScanType.Query) == false)
            {
                throw new InvalidOperationException($"Entity of type {typeof (T).Name} does not support this type of scan.");
            }

            var scanRequest = Factory.Create<IScanRequest<T>, ScanRequest<T>>();
            scanRequest.ApiKey = ApiKey;
            scanRequest.SearchQuery = searchQuery;

            var result = new ScanEnumerable<T>(scanRequest);
            return result;
        }

        public IEnumerable<T> Scan<T>(string searchQuery, IEnumerable<IEntityField> fields)
            where T : IEntityScannable, new()
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                throw new ArgumentException("searchQuery cannot be null, empty, or whitespace.", nameof(searchQuery));
            }

            if (fields == null)
            {
                throw new ArgumentNullException(nameof(fields));
            }

            if (fields.Any() == false)
            {
                throw new ArgumentException("fields must contain at least one field to retrieve", nameof(fields));
            }

            if (fields.Any(entry => entry.BelongsTo != typeof (T)))
            {
                throw new ArgumentException("All fields must be a member of the entity being scanned.", nameof(fields));
            }

            if (ValidateScanTypeSupported<T>(ScanType.Query) == false || ValidateScanTypeSupported<T>(ScanType.Fields) == false)
            {
                throw new InvalidOperationException($"Entity of type {typeof (T).Name} does not support this type of scan.");
            }

            var scanRequest = Factory.Create<IScanRequest<T>, ScanRequest<T>>();
            scanRequest.ApiKey = ApiKey;
            scanRequest.SearchQuery = searchQuery;
            scanRequest.Fields = fields;

            var result = new ScanEnumerable<T>(scanRequest);
            return result;
        }

        public IEnumerable<T> Scan<T>(IEnumerable<IEntityField> fields) where T : IEntityScannable, new()
        {
            if (fields == null)
            {
                throw new ArgumentNullException(nameof(fields));
            }

            if (fields.Any() == false)
            {
                throw new ArgumentException("fields must contain at least one field to retrieve", nameof(fields));
            }

            if (fields.Any(entry => entry.BelongsTo != typeof (T)))
            {
                throw new ArgumentException("All fields must be a member of the entity being scanned.", nameof(fields));
            }

            if (ValidateScanTypeSupported<T>(ScanType.Fields) == false)
            {
                throw new InvalidOperationException($"Entity of type {typeof (T).Name} does not support this type of scan.");
            }

            var scanRequest = Factory.Create<IScanRequest<T>, ScanRequest<T>>();
            scanRequest.ApiKey = ApiKey;
            scanRequest.Fields = fields;

            var result = new ScanEnumerable<T>(scanRequest);
            return result;
        }
        #endregion

        #region Methods
        private static bool ValidateScanTypeSupported<T>(ScanType scanType) where T : IEntityScannable, new()
        {
            return new T().ScanTypesSupported.Contains(scanType);
        }
        #endregion
    }
}