using System;
using System.Collections.Generic;
using System.Text;

namespace ICHDadJoke.Core
{
    public static class Extensions
    {
        public static int GetWordCount(this string str)
        {
            string[] userString = str.Split(new char[] { ' ', '.', '?' },
                                       StringSplitOptions.RemoveEmptyEntries);
            int wordCount = userString.Length;
            return wordCount;
        }
    }
}
