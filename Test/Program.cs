using HLTBPlugin;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<HLTBGame> games = HLTBScraper.searchGame("Metal Gear");

            foreach (HLTBGame game in games)
            {
                System.Console.Write(game.title);
                System.Console.Write(" ");
                System.Console.Write((game.mainStory > 0) ? game.mainStory.ToString() + " Hours" : "--");
                System.Console.Write(" ");
                System.Console.Write((game.mainExtra > 0) ? game.mainExtra.ToString() + " Hours" : "--");
                System.Console.Write(" ");
                System.Console.Write((game.completionist > 0) ? game.completionist.ToString() + " Hours" : "--");
                System.Console.WriteLine();
            }

            System.Console.ReadLine();
        }
    }
}
