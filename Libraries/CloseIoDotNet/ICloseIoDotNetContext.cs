namespace CloseIoDotNet
{
    using System;
    using System.Collections.Generic;
    using Entities.Definitions;
    using Entities.Fields;

    public interface ICloseIoDotNetContext : IDisposable
    {
        T Query<T>(string id) where T : IEntityQueryable, new();
        IEnumerable<T> Scan<T>() where T : IEntityScannable, new();
        IEnumerable<T> Scan<T>(IEnumerable<IEntityField> fields) where T : IEntityScannable, new();
    }
}