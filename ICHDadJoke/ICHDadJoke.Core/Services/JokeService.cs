using ICHDadJoke.Core.Extensions;
using ICHDadJoke.Core.Interfaces;
using ICHDadJoke.Core.Models;
using System.Linq;
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
            var joke = await _jokeDataClient.OnGet();

            if (joke == null) { return null; };
            return joke;
        }

        public async Task<SearchJokeModel> SearchAsync(string term)
        {
            var searchList =  await _jokeDataClient.OnSearch(term);
            if(searchList == null) { return null; }

            var list = new SearchJokeModel
            {
                LongJokes = searchList.Results.Where(x => x.Joke.GetWordCount() >= 20).ToList(),
                MediumJokes = searchList.Results.Where(x => x.Joke.GetWordCount() >= 10 &&
                    x.Joke.GetWordCount() < 20).ToList(),
                ShortJokes = searchList.Results.Where(x => x.Joke.GetWordCount() < 10).ToList(),
                Term = term
            };

            return list;
        }
    }
}