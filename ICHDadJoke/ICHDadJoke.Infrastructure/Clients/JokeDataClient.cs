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
            var joke = new JokeModel();

            var client = _clientFactory.CreateClient("icanhazdadjoke");
            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode){

                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JokeModel>(responseString);
            }

            return joke;
        }
        public async Task<SearchResultJokeModel> OnSearch(string term, int limit)
        {
            var search = new SearchResultJokeModel();

            var request = new HttpRequestMessage(HttpMethod.Get,$"search?term={term}&limit={limit}");
            var client = _clientFactory.CreateClient("icanhazdadjoke");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {

                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SearchResultJokeModel>(responseString);
            }

            return search;
        }
    }
}