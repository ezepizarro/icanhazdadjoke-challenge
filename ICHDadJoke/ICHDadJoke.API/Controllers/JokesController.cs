using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ICHDadJoke.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICHDadJoke.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IJokeService _jokeService;
        private readonly IMapper _mapper;

        public JokesController(IJokeService jokeService, IMapper mapper)
        {
            _jokeService = jokeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetRandomJokeAsync()
        {
            var joke = await _jokeService.GetRandomJokeAsync();
            return Ok(joke);
        }

        [HttpGet("Search")]
        public async Task<ActionResult> SearchAsync([FromQuery] string term)
        {
            var jokes = await _jokeService.SearchAsync(term);
            return Ok(jokes);
        }
    }
}