namespace CloseIoDotNet.Rest.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using CloseIoDotNet.Rest.Exceptions;
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
                //404
                if (HttpStatusCode.NotFound.Equals(response.StatusCode))
                {
                    throw new KeyNotFoundException("Close.Io returned 404 (not found) for your request.",
                        new CloseIoRequestException()
                        {
                            RestRequest = request,
                            RestResponse = response
                        });
                }

                //500
                if (HttpStatusCode.InternalServerError.Equals(response.StatusCode))
                {
                    throw new InternalServerErrorException(InternalServerErrorException.DefaultMessage,
                        new CloseIoRequestException()
                        {
                            RestRequest = request,
                            RestResponse = response
                        });
                }

                //0 (returned by RestSharp when no network connection available, or other networking issue.
                if (response.StatusCode == 0)
                {
                    throw new HttpRequestException("Network connection unavailable.", new CloseIoRequestException()
                    {
                        RestRequest = request,
                        RestResponse = response
                    });
                }

                //unknown
                try
                {
                    throw new CloseIoRequestException()
                    {
                        RestRequest = request,
                        RestResponse = response
                    };
                }
                catch (Exception)
                {
                    throw new CloseIoRequestException();
                }
            }
        }
        #endregion
    }
}