using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTask.Seed.GuildMessages
{
    public static class FoolsMessages
    {
        public static void AddFoolsMessages(Dictionary<string, string> messages)
        {
            messages.Add("GreetingMessageWithName", "You've met a very good friend of yours ");
            messages.Add("GreetingMessage", "Greetings, can you help me with some stuff...\n My partner clown-Jack is sick, can you replace him today\nWhat would you do?\nYou can help your friend (type \"1\") or you can just go away (type \"2\") he probably will be upset.");
            messages.Add("HelpMessage", "You helped him, at the and of the day he gave you some cash.");
            messages.Add("RejectMessage", "You decided not to help him. Sad clown goes away");
        }
    }
}
