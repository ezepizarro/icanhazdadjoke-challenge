using ICHDadJoke.Core.Interfaces;
using ICHDadJoke.Core.Models;
using ICHDadJoke.Core.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ICHDadJoke.Core.Tests.Services
{
    public class JokeServiceTests
    {
        private readonly Mock<IJokeDataClient> _client;

        public JokeServiceTests()
        {
            _client = new Mock<IJokeDataClient>();
        }

        [Fact]
        public async Task GetRandomJokeAsync_ReturnsAJoke()
        {
            // Arrange
            var joke = new JokeModel
            {
                Id = "G6EtkOZD5h",
                Joke = "A steak pun is a rare medium well done.",
                Status = 200
            };
            _client.Setup(s => s.OnGet()).Returns(Task.FromResult(joke));
            var jokeService = new JokeService(_client.Object);

            // Act
            var result = await jokeService.GetRandomJokeAsync();

            // Assert
            Assert.IsType<JokeModel>(result);
            _client.Verify();
        }

        [Fact]
        public async Task SearchAsync_ReturnsAListOfJokes()
        {
            // Arrange
            const string term = "steak";
            var searchResult = new SearchResultJokeModel
            {
                Term = term,
                TotalJokes = "6",
                Results = new List<JokeModel>
                {
                    new JokeModel
                    {
                        Id = "2gii3LeN7Ed",
                        Joke = "Why couldn't the kid see the pirate movie? Because it was rated arrr!",
                        Status = 200
                    },
                    new JokeModel
                    {
                        Id = "2gaMZLBszsc",
                        Joke = "Why did the kid throw the clock out the window? He wanted to see time fly!",
                        Status = 200
                    },
                    new JokeModel
                    {
                        Id = "18h3wcU8xAd",
                        Joke = "Why did the kid cross the playground? To get to the other slide.",
                        Status = 200
                    },
                    new JokeModel
                    {
                        Id = "FImyA5EIBAd",
                        Joke = "Did you hear about the kidnapping at school? It's ok, he woke up.",
                        Status = 200
                    },
                    new JokeModel
                    {
                        Id = "3w5wAIRZTnb",
                        Joke = "A police officer caught two kids playing with a firework and a car battery. He charged one and let the other one off.",
                        Status = 200
                    },
                    new JokeModel
                    {
                        Id = "HtcNuHJBQCd",
                        Joke = "How many kids with ADD does it take to change a lightbulb? Let's go ride bikes!",
                        Status = 200
                    },
                }
            };

            _client.Setup(s => s.OnSearch(term, 30)).Returns(Task.FromResult(searchResult));
            var jokeService = new JokeService(_client.Object);

            // Act
            var result = await jokeService.SearchAsync(term);

            // Assert
            Assert.IsType<SearchJokeModel>(result);
           
            Assert.NotEmpty(result.LongJokes);
            Assert.NotEmpty(result.MediumJokes);
            Assert.Empty(result.ShortJokes);

            Assert.Single(result.LongJokes);

            Assert.Equal(5, (int)result.MediumJokes.Count);

            _client.Verify();
        }
    }
}
