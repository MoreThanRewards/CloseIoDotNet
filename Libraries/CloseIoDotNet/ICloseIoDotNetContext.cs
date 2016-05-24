namespace CloseIoDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using Entities.Definitions;
    using Entities.Fields;

    public interface ICloseIoDotNetContext : IDisposable
    {
        #region Properties
        string ApiKey { set; }
        #endregion

        #region Methods
        T Query<T>(string id) where T : IEntityQueryable, new();
        T Query<T>(string id, IEnumerable<IEntityField> fields) where T : IEntityQueryable, new();
        IEnumerable<T> Scan<T>() where T : IEntityScannable, new();
        IEnumerable<T> Scan<T>(string searchQuery) where T : IEntityScannable, new();
        IEnumerable<T> Scan<T>(string searchQuery, IEnumerable<IEntityField> fields) where T : IEntityScannable, new();
        IEnumerable<T> Scan<T>(IEnumerable<IEntityField> fields) where T : IEntityScannable, new();
        #endregion
    }
}