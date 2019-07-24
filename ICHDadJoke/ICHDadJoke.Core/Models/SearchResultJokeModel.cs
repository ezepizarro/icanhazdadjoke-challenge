using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICHDadJoke.Core.Models
{
    public class SearchResultJokeModel
    {
        [JsonProperty("search_term")]
        public string Term { get; set; }
        [JsonProperty("total_jokes")]
        public string TotalJokes { get; set; }
        public ICollection<JokeModel> Results { get; set; }
    }
}
