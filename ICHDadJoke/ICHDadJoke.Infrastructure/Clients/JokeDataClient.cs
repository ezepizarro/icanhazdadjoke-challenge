using ICHDadJoke.Core.Interfaces;
using ICHDadJoke.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ICHDadJoke.Infrastructure.Clients
{
    public class JokeDataClient : IJokeDataClient
    {
        private readonly IHttpClientFactory _clientFactory;

        public JokeDataClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<JokeModel> OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://icanhazdadjoke.com/");
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode){

                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JokeModel>(responseString);
            }

            return null;
        }
    }
}