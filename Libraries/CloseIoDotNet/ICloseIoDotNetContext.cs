namespace CloseIoDotNet
{
    using System;
    using System.Collections.Generic;
    using Entities.Definitions;
    using Rest.MetaEntities;

    public interface ICloseIoDotNetContext : IDisposable
    {
        T Query<T>(string id) where T : IEntityQueryable, new();
        IEnumerable<T> Scan<T>() where T : IEntityScannable, new();
    }
}