using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICHDadJoke.Core.Extensions
{
    public static class Extensions
    {
        public static int GetWordCount(this string str)
        {
            string[] userString = str.Split(new char[] { ' ', '.', '?', ':', '!', '\n', '\r' },
                                       StringSplitOptions.RemoveEmptyEntries);
            int wordCount = userString.Length;

            return wordCount;

        }
        public static int GetWordCountLinq(this string str)
        {
            var punctuation = str.Where(char.IsPunctuation).Distinct().ToArray();
            var words = str.Split().Select(x => x.Trim(punctuation)).Where(e => !string.IsNullOrEmpty(e)).ToArray();
            int wordCount = words.Length;

            return wordCount;
        }
    }
}