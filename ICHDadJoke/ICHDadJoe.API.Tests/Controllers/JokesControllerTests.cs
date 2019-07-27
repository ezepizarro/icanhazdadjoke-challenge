using AutoMapper;
using ICHDadJoke.API.Controllers;
using ICHDadJoke.Core.Interfaces;
using ICHDadJoke.Core.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ICHDadJoe.API.Tests.Controllers
{
    public class JokesControllerTests
    {
        private readonly Mock<IJokeDataClient> _client;
        private readonly Mock<ILogger> _logger;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IJokeService> _jokeService;

        public JokesControllerTests()
        {
            _client = new Mock<IJokeDataClient>();
            _logger = new Mock<ILogger>();
            _mapper = new Mock<IMapper>();
            _jokeService = new Mock<IJokeService>();
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
            var controller = new JokesController(_jokeService.Object, _mapper.Object, _logger.Object);
            // Act
            // Assert
        }

        [Fact]
        public async Task SearchAsync_ReturnsAListOfJokes()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
