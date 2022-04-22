using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTask.Seed.GuildMessages
{
    public static class AssassinsMessages
    {
        public static void AddAssassinsMessages(Dictionary<string, string> messages)
        {
            messages.Add("GreetingMessage", "You found out that you’re under Assassins Guild contract\nWhat would you do?");
            messages.Add("ChooseMessage", "You can pay some money to hire an assassin for your protection (type \"1\") or you can pray for your life (type \"2\").");
            messages.Add("LooseMessage", "You lost a chance to make decision. Now you die!");
            messages.Add("AskingForMoneyMessage", "Please, tell me how much you can pay for your life? :");
            messages.Add("LostChanceMessage", "You have lost your chance to hire an assassin. Try again!");
            messages.Add("NoMoneyMessage", "Your pockets are empty");
            messages.Add("SuccessMessage", "You successfully hired professional assassin, but it turned out that no one was hunting for you");
            messages.Add("NoAssassinsMessage", "There are no assassins for your amount of gold.");
            messages.Add("DeadFromAssassinMessage", "You decided to choose death! Assassin kills you!");
        }
    }
}
