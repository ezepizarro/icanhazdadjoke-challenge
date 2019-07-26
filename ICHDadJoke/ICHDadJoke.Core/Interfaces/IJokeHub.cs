using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICHDadJoke.Core.Interfaces
{
    public interface IJokeHub
    {
        Task BroadcastMessage(string message);
    }
}
