namespace CloseIoDotNet
{
    using System;
    using Entities.Definitions;
    using Rest.Entities.Requests;

    public interface ICloseIoDotNetContext : IDisposable
    {
        T Query<T>(string id) where T : IEntityQueryable, new();
    }
}