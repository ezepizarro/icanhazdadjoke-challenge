using ICHDadJoke.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace ICHDadJoke.API.Hubs
{
    public class Worker : BackgroundService
    {
        public IServiceScopeFactory _serviceScopeFactory;
        public readonly ILogger<Worker> _logger;
        private readonly IHubContext<JokeHub, IJokeHub> _hub;
        

        public Worker(IServiceScopeFactory serviceScopeFactory, IHubContext<JokeHub, IJokeHub> hub, ILogger<Worker> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _hub = hub;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SignalR Background Service started");
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    IJokeDataClient scoped = scope.ServiceProvider.GetRequiredService<IJokeDataClient>();
                    var response = await scoped.OnGet();
                    await _hub.Clients.All.BroadcastMessage(response.Joke);
                    await Task.Delay(TimeSpan.FromSeconds(10));
                }
            }
        }
    }
}