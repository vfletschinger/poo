using Models.SpaceShips;

namespace Models
{
    public class Player : IPlayer
    {
        private readonly string FirstName;
        private readonly string LastName;

        public string Alias { get; }

        public string Name => $"{FirstName} {LastName}";

        public Spaceship BattleShip { get; set; }

        public Player(string FirstName, string LastName, string Alias)
        {
            this.FirstName = FormatString(FirstName);
            this.LastName = FormatString(LastName);
            this.Alias = Alias;
            this.BattleShip = new Spaceship("ViperMKII", 10, 15);
        }

        private static string FormatString(string stringToFormat)
        {
            if (string.IsNullOrEmpty(stringToFormat))
            {
                throw new ArgumentException("Paramètre invalide !");
            }

            return stringToFormat.Substring(0, 1).ToUpper() + stringToFormat.Substring(1).ToLower();
        }

        public override string ToString()
        {
            return $"{Alias} ({Name})";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Player other)
            {
                return false;
            }

            return other.Alias == this.Alias;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Alias);
        }
    }
}
