﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ICHDadJoke.API.Hubs;
using ICHDadJoke.Core.Interfaces;
using ICHDadJoke.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ICHDadJoke.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IJokeService _jokeService;

        public JokesController(IJokeService jokeService, IMapper mapper, ILogger<JokesController> logger)
        {
            _jokeService = jokeService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(JokeModel), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetRandomJokeAsync()
        {
            _logger.LogInformation("Getting a random joke");

            var joke = await _jokeService.GetRandomJokeAsync();
            if (joke == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"Returning a random joke:{JsonConvert.SerializeObject(joke)}");

            return Ok(joke);
        }

        [HttpGet("Search")]
        [ProducesResponseType(typeof(SearchJokeModel), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> SearchAsync([FromQuery] string term)
        {
            _logger.LogInformation($"Searching for a list of jokes by term: {term}");

            var jokes = await _jokeService.SearchAsync(term);
            if (jokes == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"Returning a list of jokes:{JsonConvert.SerializeObject(jokes)}");

            return Ok(jokes);
        }
    }
}