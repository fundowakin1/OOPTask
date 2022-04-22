using System.Collections.Generic;

namespace OOPTask.Seed.GuildMessages
{
    public static class BeggarsMessages
    {
        public static void AddBeggarsMessages(Dictionary<string, string> messages)
        {
            messages.Add("GreetingMessageBeer", "You see a person with placard Saying \"Why lie? I need a beer.\"\nHe doesn't bother you");
            messages.Add("GreetingMessageName", "You've met poor man in baggy clothes, his name - ");
            messages.Add("GreetingMessageFinal", "- Please, give me some coins, good fellow\n How does he know your name?\nWhat would you do?\nYou can give him some money (type \"1\") or you can try your best to run away (type \"2\").");
            messages.Add("ChasedToDeathMessage", "You have been chased to death");
            messages.Add("GiveMoneyMessage", "You peacefully gave your cash to this beggar.");
            messages.Add("NotGivingMoneyMessage", "You decided not to give him money. A bad idea. You have been chased to death");
        }
    }
}
