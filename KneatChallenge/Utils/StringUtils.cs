using System;
using System.Collections.Generic;
using System.Text;

namespace KneatChallenge.ConsoleApp.Utils
{
    public static class StringUtils
    {

        public static string spaceGenerator(string word, int distance)
        {
            string result = string.Empty;
            for (int i = 0; i < (distance - word.Length); i++)
                result += " ";
            return result;
        }
    }
}
