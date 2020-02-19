using System;
using System.Collections.Generic;
using System.Drawing;

namespace KneatChallenge.ConsoleApp
{

    public static class Menu
    {
        public static Dictionary<string, char> actions = new Dictionary<string, char>
    {
        {"info", '1'},
        {"stop", '2'}
    };
        public static char showMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("KNEATChallengeApp");
            Console.ResetColor();
            
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("Press " + actions["info"] + " to Show starships Info.");
            Console.WriteLine("Press " + actions["stop"] + " to Calculate the number of stops required for each starship to make a distance.");
            Console.WriteLine("Press any other character to exit.");
            char ch;

            Console.Write("Enter a number of the menu: ");
            //ch = Console.ReadLine()[0];
            ch = Console.ReadKey().KeyChar;
            Console.Clear();
            return ch;
        }
    }
}
