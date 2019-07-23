using ICHDadJoke.Core.Interfaces;
using ICHDadJoke.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ICHDadJoke.Core.Services
{
    public class JokeService : IJokeService
    {
        private readonly IJokeDataClient _jokeDataClient;

        public JokeService(IJokeDataClient jokeDataClient)
        {
            _jokeDataClient = jokeDataClient;
        }

        public async Task<JokeModel> GetRandomJokeAsync()
        {
            try
            {
                return await _jokeDataClient.OnGet();
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}