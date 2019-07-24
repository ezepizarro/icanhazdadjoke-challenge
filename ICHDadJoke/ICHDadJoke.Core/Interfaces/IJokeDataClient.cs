using ICHDadJoke.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICHDadJoke.Core.Interfaces
{
    public interface IJokeDataClient
    {
        Task<JokeModel> OnGet();
        Task<SearchResultJokeModel> OnSearch(string term, int limit = 30);
    }
}