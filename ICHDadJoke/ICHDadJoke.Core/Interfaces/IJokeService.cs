﻿using ICHDadJoke.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICHDadJoke.Core.Interfaces
{
    public interface IJokeService
    {
        Task<JokeModel> GetRandomJokeAsync();
        Task<SearchJokeModel> SearchAsync(string term);
    }
}
