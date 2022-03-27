namespace OOPTask
{
    public class PlayerInfo
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public int AmountOfMoney { get; set; }
        
        public Player Player { get; set; }
    }
}