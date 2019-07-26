using ICHDadJoke.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICHDadJoke.API.Hubs
{
    public class JokeHub : Hub<IJokeHub>
    {
        public JokeHub()
        {
        }
    }
}
