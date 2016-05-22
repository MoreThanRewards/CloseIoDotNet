namespace CloseIoDotNet.Rest.Entities
{
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;

    public interface IScanEnumerable<T> : IEnumerable<T> where T : IEntity, IEntityScannable
    {
         
    }
}