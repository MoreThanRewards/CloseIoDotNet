namespace CloseIoDotNet.Rest.Exceptions
{
    using System;
    public class InternalServerErrorException : Exception
    {
        #region Constants
        public const string DefaultMessage =
            "Close.Io encountered an unexpected internal server error (HTTP 500) while processing your request.";
        #endregion

        #region Constructors
        public InternalServerErrorException() : base(DefaultMessage) { }

        public InternalServerErrorException(string message) : base(message) { }

        public InternalServerErrorException(string message, Exception innerException) : base(message, innerException) { }
        #endregion
    }
}