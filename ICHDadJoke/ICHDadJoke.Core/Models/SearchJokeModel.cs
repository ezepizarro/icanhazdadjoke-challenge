using System;
using System.Collections.Generic;
using System.Text;

namespace ICHDadJoke.Core.Models
{
    public class SearchJokeModel
    {
        public string Term { get; set; }
        public List<JokeModel> ShortJokes  { get; set; }
        public List<JokeModel> MediumJokes { get; set; }
        public List<JokeModel> LongJokes { get; set; }
    }
}
