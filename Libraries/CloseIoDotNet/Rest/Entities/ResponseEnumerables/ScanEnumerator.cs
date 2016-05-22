namespace CloseIoDotNet.Rest.Entities.ResponseEnumerables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;
    using Requests;
    using Responses;

    public class ScanEnumerator<T> : IEnumerator<T> where T : IEntityScannable, new()
    {
        #region Constants
        private const int Limit = 100;
        private const int DefaultIndex = -1;
        private static readonly int DefaultSkip = Math.Abs(Limit)*-1;
        #endregion

        #region Instance Variables
        private List<T> _data;
        private int? _index;
        private int? _skip;
        private bool? _hasMore;
        private T _currentEntry;
        private ScanRequest<T> _scanRequest;
        #endregion

        #region Properties
        private List<T> Data
        {
            get { return _data ?? (_data = new List<T>()); }
            set { _data = value; }
        }
        private T CurrentEntry
        {
            get
            {
                if (_currentEntry == null)
                {
                    throw new InvalidOperationException("CurrentEntry not initialized.");
                }
                return _currentEntry;
            }
            set { _currentEntry = value; }
        }
        private int Index
        {
            get
            {
                if (_index.HasValue == false)
                {
                    _index = DefaultIndex;
                }
                return _index.Value;
            }
            set { _index = value; }
        }
        private int Skip
        {
            get
            {
                if (_skip.HasValue == false)
                {
                    _skip = DefaultSkip;
                }
                return _skip.Value;
            }
            set { _skip = value; }
        }
        private bool HasMore
        {
            get { return _hasMore ?? (_hasMore = true).Value; }
            set { _hasMore = value; }
        }
        public ScanRequest<T> ScanRequest
        {
            get
            {
                if (_scanRequest == null)
                {
                    throw new InvalidOperationException();
                }
                return _scanRequest;
            }
            set { _scanRequest = value; }
        }
        #endregion

        #region Constructors
        public ScanEnumerator() { }

        public ScanEnumerator(ScanRequest<T> scanRequest)
        {
            ScanRequest = scanRequest;
        } 
        #endregion

        #region Methods - Interface
        public void Dispose()
        {
            Data.Clear();
            Data = null;
            _index = null;
            _skip = null;
            _hasMore = null;
            _currentEntry = default(T);
        }

        public bool MoveNext()
        {
            if ((Index + 1) >= Data.Count)
            {
                if (HasMore == false)
                {
                    return false;
                }
                else
                {
                    var nextPage = LoadNextPage();
                    Data.Clear();
                    Index = DefaultIndex;
                    Data.AddRange(nextPage.Data);
                    HasMore = nextPage.HasMore;
                    return MoveNext();
                }
            }
            else
            {
                Index += 1;
                Current = Data[Index];
                return true;
            }
        }

        public void Reset()
        {
            Index = DefaultIndex;
            Skip = DefaultSkip;
            Data.Clear();
            CurrentEntry = default(T);
        }

        public T Current
        {
            get
            {
                return CurrentEntry;
            }
            set { CurrentEntry = value; }
        }

        object IEnumerator.Current => Current;

        #endregion

        #region Methods
        private int IterateSkip()
        {
            if (HasMore == false)
            {
                throw new InvalidProgramException("No more pages to iterate through.");
            }

            return (Skip += Limit);
        }

        private ScanResponse<T> LoadNextPage()
        {
            var skip = IterateSkip();
            var limit = Limit;

            var request = ScanRequest.CreateBaseRestRequest(skip, limit);
            var response = ScanRequest.ExecuteScanRestRequest(request);

            return response;
        }
        #endregion
    }
}