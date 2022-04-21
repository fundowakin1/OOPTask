namespace OOPTask.Models
{
    public class PlayerInfoEntity
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public decimal AmountOfMoney { get; set; }
        
        public virtual PlayerEntity PlayerEntity { get; set; }
    }
}