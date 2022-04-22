using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTask.Seed.GuildMessages
{
    public static class ThievesMessages
    {
        public static void AddThievesMessages(Dictionary<string, string> messages)
        {
            messages.Add("GreetingMessageWithName", "Poor you. You've met ditty thief ");
            messages.Add("GreetingMessage", "- He-he! Turn out your pockets!\nWhat would you do?\nYou can give him some money (type \"1\") or you can try your best to run away (type \"2\").");
            messages.Add("DeathThieveMessage", "No money, no life(");
            messages.Add("GiveCashMessage", "You peacefully gave your cash to this thief.");
            messages.Add("RejectMessage", "You decided to choose death! Thief stabbed you in the back(");
        }
    }
}
