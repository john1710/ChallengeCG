using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json.Serialization;
using System.Threading;
using Web.Data.Input;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class AccountService : IAccountService
    {

        /*
         
var options = new RestClientOptions("https://api.twitter.com/1.1") {
    Authenticator = new HttpBasicAuthenticator("username", "password")
};
var client = new RestClient(options);
var request = new RestRequest("statuses/home_timeline.json");
// The cancellation token comes from the caller. You can still make a call without it.
var response = await client.GetAsync(request, cancellationToken);
        */
        private readonly RestClient httpClient;
        public AccountService()
        {
            var options = new RestClientOptions("https://localhost:7192/api");
            httpClient = new RestClient(options);
        }
        public async Task<AccountViewModel> Create(UpsertAccountInput entity)
        {
            var request = new RestRequest("account", Method.Post);
            string jsonToSend = JsonConvert.SerializeObject(entity);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddBody(jsonToSend);
            request.RequestFormat = DataFormat.Json;
            return await httpClient.PostAsync<AccountViewModel>(request) ?? throw new Exception("error on create account");
        }

        public async Task Delete(long id)
        {
            var request = new RestRequest($"account/{id}", Method.Delete);

             await httpClient.DeleteAsync(request);
        }

        public async Task<List<AccountViewModel>> GetAll()
        {
            var request = new RestRequest("account");
            var response = await httpClient.GetAsync<List<AccountViewModel>>(request);
            return response?.ToList() ?? new List<AccountViewModel>();
        }

        public async Task<AccountViewModel> GetById(long id)
        {
            var request = new RestRequest($"account/{id}");
            return await httpClient.GetAsync<AccountViewModel>(request) ?? throw new Exception("not found account");
        }

        public async Task<AccountViewModel> Update(UpsertAccountInput entity)
        {
            var request = new RestRequest($"account/{entity.Id}", Method.Post);
            string jsonToSend = JsonConvert.SerializeObject(entity);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddBody(jsonToSend);
            request.RequestFormat = DataFormat.Json;
            return await httpClient.PostAsync<AccountViewModel>(request) ?? throw new Exception("error on update account");
        }
    }
}
