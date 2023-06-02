using API.Data;
using API.Interfaces.Services;
using RestSharp;
using RestSharp.Authenticators;

namespace API.Services
{
    public class AddressService : IAddressService
    {
        private RestClient httpClient;

        public AddressService()
        {
            var options = new RestClientOptions("http://viacep.com.br/ws")
            {
                Authenticator = new HttpBasicAuthenticator("username", "password")
            };
            httpClient = new RestClient(options);
        }
        public async Task<AddressViewModel> GetAddressByCep(string cep)
        {
            var request = new RestRequest($"{cep}/json/");
            return await httpClient.GetAsync<AddressViewModel>(request) ?? throw new Exception("cep not found.");
        }
    }
}
