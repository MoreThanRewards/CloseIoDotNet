namespace CloseIoDotNet.Rest.Exceptions
{
    using System;
    using System.Net;
    using RestSharp;

    public class CloseIoRequestException : Exception
    {
        #region Constants
        private const string DefaultMessage =
            "Close.Io returned an unknown error to your request";
        #endregion

        #region Instance Variables
        private HttpStatusCode? _statusCode;
        private string _body;
        #endregion

        #region Properties
        public IRestRequest RestRequest { get; set; }
        public IRestResponse RestResponse { get; set; }
        public HttpStatusCode ResponseStatusCode
        {
            get
            {
                if (_statusCode.HasValue == false)
                {
                    try
                    {
                        _statusCode = RestResponse.StatusCode;
                    }
                    catch (Exception)
                    {
                        _statusCode = new HttpStatusCode();
                    }
                }
                return _statusCode.Value;
            }
            set { _statusCode = value; }
        }
        public string ResponseBody
        {
            get
            {
                if (_body == null)
                {
                    try
                    {
                        _body = RestResponse.Content;
                    }
                    catch (Exception)
                    {
                        _body = string.Empty;
                    }
                }
                return _body;
            }
            set { _body = value; }
        }

        #endregion

        #region Constructors
        public CloseIoRequestException() : base(DefaultMessage) { }

        public CloseIoRequestException(string message) : base(message) { }

        public CloseIoRequestException(string message, Exception innerException) : base(message, innerException) { }
        #endregion
    }
}