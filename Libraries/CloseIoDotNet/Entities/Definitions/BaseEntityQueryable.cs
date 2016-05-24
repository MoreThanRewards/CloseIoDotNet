namespace CloseIoDotNet.Entities.Definitions
{
    using System;

    public class BaseEntityQueryable : IEntityQueryable
    {
        #region Constants
        public const string QueryResourceIdKey = "{id}";
        #endregion

        #region Properties
        public string QueryResourceFormat { get; set; }
        #endregion

        #region Methods - Interface
        public string GenerateQueryResource(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is required and cannot be null or empty.", nameof(id));
            }

            var result = QueryResourceFormat.Replace(QueryResourceIdKey, id);

            return result;
        }
        #endregion
    }
}