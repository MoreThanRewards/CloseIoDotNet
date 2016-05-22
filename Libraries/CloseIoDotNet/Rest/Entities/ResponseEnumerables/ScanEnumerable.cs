namespace CloseIoDotNet.Rest.Entities.ResponseEnumerables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;
    using Requests;

    public class ScanEnumerable<T> : IScanEnumerable<T> where T : IEntity, IEntityScannable, new()
    {
        #region Instance Variables
        private ScanRequest<T> _scanRequest;
        private IEnumerator<T> _enumerator;
        #endregion

        #region Properties
        public ScanRequest<T> ScanRequest
        {
            get
            {
                if (_scanRequest == null)
                {
                    throw new InvalidOperationException("ScanRequest not initialized.");
                }
                return _scanRequest;
            }
            set { _scanRequest = value; }
        }

        private IEnumerator<T> Enumerator
        {
            get { return _enumerator ?? (_enumerator = new ScanEnumerator<T>(ScanRequest)); }
            set { _enumerator = value; }
        }
        #endregion

        #region Constructors
        public ScanEnumerable() { }
        public ScanEnumerable(ScanRequest<T> scanRequest)
        {
            ScanRequest = scanRequest;
        }
        #endregion

        #region Methods - Interface
        public IEnumerator<T> GetEnumerator()
        {
            return Enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

    }
}