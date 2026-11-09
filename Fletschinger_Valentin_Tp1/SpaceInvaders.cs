using Models;
using Models.SpaceShips;
using SpaceInvadersArmory;

namespace Fletschinger_Valentin_Tp1
{
    internal class SpaceInvaders
    {
        private readonly List<Player> players = new List<Player>();
        private readonly Armory armory;

        public SpaceInvaders()
        {
            armory = new Armory();
            Spaceship.Armory = armory;
            Init();
        }

        static void Main(string[] args)
        {
            SpaceInvaders spaceInvaders = new SpaceInvaders();

            foreach (Player player in spaceInvaders.players)
            {
                Console.WriteLine(player.ToString());
            }
            Console.WriteLine();

            spaceInvaders.armory.ViewArmory();
            Console.WriteLine();

            // Équipe le vaisseau du premier joueur de deux armes de l'armurerie
            Spaceship ship = spaceInvaders.players[0].BattleShip;
            ship.AddWeapon(spaceInvaders.armory.Weapons[0]);
            ship.AddWeapon(spaceInvaders.armory.Weapons[1]);
            ship.ViewShip();
            Console.WriteLine();

            // Troisième arme : OK. Quatrième : dépasse MaxWeapons
            ship.AddWeapon(spaceInvaders.armory.Weapons[2]);
            try
            {
                ship.AddWeapon(spaceInvaders.armory.Weapons[3]);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }

            // 11.a : arme qui ne fait pas partie de l'armurerie
            try
            {
                ship.AddWeapon(new Weapon("Canon à confettis", 1, 2, EWeaponType.Direct, 1));
            }
            catch (ArmoryException e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }

        private void Init()
        {
            players.Add(new Player("Donald", "Trump", "PrixNobelDeLaPaix"));
            players.Add(new Player("Michael", "Jackson", "HeeHee"));
            players.Add(new Player("Jim", "Carrey", "LeGrinch"));
        }
    }
}
