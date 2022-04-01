namespace OOPTask.Models
{
    public class PlayerEntity
    {
        public int Id { get; set; }
        public int AmountOfTurns { get; set; }
        public PlayerInfoEntity PlayerInfoEntity { get; set; }
    }
}