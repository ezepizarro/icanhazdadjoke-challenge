using ICHDadJoke.Core.Interfaces;
using ICHDadJoke.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<SearchJokeModel> SearchAsync(string term)
        {
            try
            {
                var searchList =  await _jokeDataClient.OnSearch(term);

                var list = new SearchJokeModel
                {
                    LongJokes = searchList.Results.Where(x => x.Joke.GetWordCount() >= 20).ToList(),
                    MediumJokes = searchList.Results.Where(x => x.Joke.GetWordCount() < 20).ToList(),
                    ShortJokes = searchList.Results.Where(x => x.Joke.GetWordCount() < 10).ToList(),
                    Term = term
                };

                return list;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}