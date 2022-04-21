using System;
using OOPTask.Contexts;

namespace OOPTask.Output
{
    internal class ScoreTable
    {
        private static PlayerContext PlayerContext { get; set; }

        public static void OutputScoreTable()
        {
            Console.WriteLine("\n\n\nDo you want to see score table?\nIf the answer is yes, press \"1\"");
            var playersAnswer = Console.ReadLine();
            if (playersAnswer=="1")
            {
                PlayerContext = new PlayerContext();
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("|      Player's Name           |  Race   | Turns | End | Status  |");
                foreach (var player in PlayerContext.Players)
                {
                    Console.WriteLine("|----------------------------------------------------------------|");
                    Console.Write($"|{player.PlayerInfoEntity.Name,30}|{player.PlayerInfoEntity.Race,9}|{player.AmountOfTurns,7}|");
                    Console.Write(player.HasWon ? "  Won |  Alive |\n" : " Lost |  Dead  |\n");
                }
                Console.WriteLine("------------------------------------------------------------------");
            }

            Console.WriteLine("Thanks for playing!");
            
        }

    }
}
