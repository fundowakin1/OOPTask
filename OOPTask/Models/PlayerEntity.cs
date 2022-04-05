namespace OOPTask.Models
{
    public class PlayerEntity
    {
        public int Id { get; set; }
        public int AmountOfTurns { get; set; }
        public bool IsAlive { get; set; }
        public virtual PlayerInfoEntity PlayerInfoEntity { get; set; }
    }
}