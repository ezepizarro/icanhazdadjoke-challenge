using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ICHDadJoke.API.Hubs;
using ICHDadJoke.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ICHDadJoke.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IJokeService _jokeService;
        private readonly IMapper _mapper;
        private IHubContext<JokeHub, IJokeHub> _hubContext;
        private Timer _timer;

        public JokesController(IJokeService jokeService, IMapper mapper, IHubContext<JokeHub, IJokeHub> hubContext)
        {
            _jokeService = jokeService;
            _mapper = mapper;
            _hubContext = hubContext;
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