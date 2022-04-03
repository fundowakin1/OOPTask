namespace OOPTask.GameEntities.Player
{
    public class Player
    {
        private string _name;
        private string _sex;
        private string _race;
        private decimal _amountOfMoney = 100m;

        protected Player(string name, string sex, int raceId)
        {
            _name = name;
            _sex = sex;
            _race = raceId switch
            {
                1 => Races.Human.ToString(),
                2 => Races.Elven.ToString(),
                3 => Races.Gnome.ToString(),
                4 => Races.Vampire.ToString(),
                _ => Races.Human.ToString()
            };
            if (string.Equals(_race,"Elven"))
            {
                _amountOfMoney = 150m;
            }
        }
    }
}