using ICHDadJoke.Core.Models;
using ICHDadJoke.Core.Extensions;
using Xunit;

namespace ICHDadJoke.Core.Tests.Extensions
{
    public class ExtensionsTests
    {
        [Fact]
        public void GetWordUsingSplitArray()
        {
            // Arrange
            var joke = new JokeModel
            {
                Id = "G6EtkOZD5h",
                Joke = "A steak pun is a rare medium well done.",
                Status = 200
            };

            // Act
            var result = joke.Joke.GetWordCount();

            // Assert
            Assert.Equal(9, result);
        }
        [Fact]
        public void GetWordUsingLinq()
        {
            // Arrange
            var joke = new JokeModel
            {
                Id = "G6EtkOZD5h",
                Joke = "A steak pun is a rare medium well done.",
                Status = 200
            };

            // Act
            var result = joke.Joke.GetWordCountLinq();

            // Assert
            Assert.Equal(9, result);
        }
    }
}
