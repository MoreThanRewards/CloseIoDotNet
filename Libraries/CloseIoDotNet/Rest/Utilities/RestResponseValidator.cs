namespace CloseIoDotNet.Rest.Utilities
{
    using System;
    using System.Net;
    using RestSharp;

    public class RestResponseValidator : IRestResponseValidator
    {
        #region Methods - Interface
        public void Validate(IRestRequest request, IRestResponse response)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            if (
                response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.NoContent &&
                response.StatusCode != HttpStatusCode.Created &&
                response.StatusCode != HttpStatusCode.Accepted &&
                response.StatusCode != HttpStatusCode.PartialContent
                )
            {
                //TODO inspect response type and body, issue specific exceptions
                throw new InvalidOperationException();
            }
        }
        #endregion
    }
}