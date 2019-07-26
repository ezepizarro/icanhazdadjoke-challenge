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
        private readonly IHubContext<JokeHub, IJokeHub> _hub;
        private Timer _timer;

        public Worker(IServiceScopeFactory serviceScopeFactory, IHubContext<JokeHub, IJokeHub> hub)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _hub = hub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
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