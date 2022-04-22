using System.Collections.Generic;
using OOPTask.GameEntities;

namespace OOPTask.Seed.GuildMessages
{
    public static class GeneralMessages
    {
        public static void AddGeneralMessages(Dictionary<string, string> messages)
        {
            messages.Add("EndOfRetriesMessage", "You should have followed instructions and haven't written this bullshit!");
            messages.Add("VariantsMessage", "Please, write 1 or 2!");
            messages.Add("RetriesMessage", "Number of retries: ");
            messages.Add("GreetingSpecialChosenMemberMessage", "You feel some strange aura which emanates from this creep... (type \"3\" to find out what it is)");
            messages.Add("VampireCaseWonMessage", "You have met another vampire. After a long battle you won. His power now yours!");
            messages.Add("VampireCaseLostMessage", "Oh no, this is vampire! You die(");
            messages.Add("MageCaseWonMessage", "You have met mage. You thought that fighting him will be a good practice for you!\nYou have won! But city has burnt(");
            messages.Add("MageCaseLostMessage", "Oh no, this is mage! He made from you a well-done steak(");
            messages.Add("Vampire-mageMessage", "Oh no, this is vampire-mage! He made from you a medium-rare steak. You will be great meal for him");
        }
    }
}
