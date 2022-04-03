using System;
using OOPTask.Contexts;

namespace OOPTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // var money = 100;
            // Console.WriteLine("Hello wanderer!\nWelcome to the fine city of Ankh-Morpork!\n" +
            //                   "This is the story of how you died\n\n", 
            //     Console.ForegroundColor = ConsoleColor.Red);
            // Console.ForegroundColor = ConsoleColor.Gray;
            //
            // while (true)
            // {
            //     var random = RandomNumberGenerator.GetInt32(1, 5);
            //
            //     switch (random)
            //     {
            //         case 1:
            //             Console.WriteLine("You've met the Assassin guild member");
            //             break;
            //         case 2:
            //             Console.WriteLine("You've met thieve");
            //             break;
            //         case 3:
            //             Console.WriteLine("Beggars' Guild member followed you on the heels");
            //             break;
            //         case 4:
            //             Console.WriteLine("You've met the fool from College of Clowns");
            //             Console.WriteLine("Can you help me, brother?");
            //             break;
            //     }
            //     
            //     Console.WriteLine($"Your current balance is {money}AM$");
            //    
            var playerDb = new PlayerContext();
            var guildDB = new GuildContext();
            Console.WriteLine("Type enter to delete db");
            Console.ReadLine();
        }
        
    }
}