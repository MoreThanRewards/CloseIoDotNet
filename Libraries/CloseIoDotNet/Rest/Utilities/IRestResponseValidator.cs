namespace CloseIoDotNet.Rest.Utilities
{
    using CloseIoDotNet.Entities.Definitions;
    using RestSharp;

    public interface IRestResponseValidator
    {
        void Validate(IRestRequest request, IRestResponse response);
    }
}