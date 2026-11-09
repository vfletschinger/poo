using SpaceInvadersArmory;

namespace Models.SpaceShips
{
    public class Spaceship : ISpaceship
    {
        // Choix pour le 11.a : l'armurerie est un membre static de Spaceship.
        // Il n'existe qu'une seule armurerie dans le jeu, partagée par tous les vaisseaux :
        // un membre static correspond exactement à cette idée.
        // Seul le vaisseau a besoin de la lire : le get est privé, seul le set est public.
        public static Armory? Armory { private get; set; }

        private readonly List<Weapon> weapons = new List<Weapon>();

        public string Name { get; }
        public double MaxStructure { get; }
        public double MaxShield { get; }
        public double CurrentStructure { get; private set; }
        public double CurrentShield { get; private set; }

        public bool IsDestroyed => CurrentStructure <= 0;

        public int MaxWeapons => 3;

        public IReadOnlyList<Weapon> Weapons => weapons;

        // Somme des dégâts moyens de toutes les armes du vaisseau
        public double AverageDamages
        {
            get
            {
                double total = 0;
                foreach (Weapon weapon in weapons)
                {
                    total += weapon.AverageDamage;
                }
                return total;
            }
        }

        public Spaceship(string Name, double MaxStructure, double MaxShield)
        {
            this.Name = Name;
            this.MaxStructure = MaxStructure;
            this.MaxShield = MaxShield;
            this.CurrentStructure = MaxStructure;
            this.CurrentShield = MaxShield;
        }

        public void AddWeapon(Weapon weapon)
        {
            if (Armory != null && !Armory.Contains(weapon))
            {
                throw new ArmoryException($"L'arme {weapon.Name} ne fait pas partie de l'armurerie !");
            }

            if (weapons.Count >= MaxWeapons)
            {
                throw new InvalidOperationException($"Le vaisseau {Name} ne peut pas porter plus de {MaxWeapons} armes !");
            }

            weapons.Add(weapon);
        }

        // Réponse à la question de réflexion :
        // List.Remove cherche l'élément à retirer en appelant Equals sur chaque élément.
        // Weapon ne redéfinit pas Equals, c'est donc celui de Object qui est utilisé :
        // il compare les références (même objet en mémoire), pas le contenu.
        // Si on passe une autre instance de Weapon portant le même nom, Remove ne la trouve
        // pas, ne retire rien et renvoie false. Pour retirer "par nom", il faudrait redéfinir
        // Equals (et GetHashCode) dans Weapon en comparant Name, comme pour Player.
        public void RemoveWeapon(Weapon weapon)
        {
            weapons.Remove(weapon);
        }

        public void ClearWeapons()
        {
            weapons.Clear();
        }

        public void ViewWeapons()
        {
            if (weapons.Count == 0)
            {
                Console.WriteLine("   Aucune arme");
                return;
            }

            foreach (Weapon weapon in weapons)
            {
                Console.WriteLine("   - " + weapon);
            }
        }

        public void ViewShip()
        {
            Console.WriteLine($"=== Vaisseau {Name} ===");
            Console.WriteLine($" Structure : {CurrentStructure}/{MaxStructure}");
            Console.WriteLine($" Bouclier  : {CurrentShield}/{MaxShield}");
            Console.WriteLine(" Armes :");
            ViewWeapons();
            Console.WriteLine($" Dégâts moyens : {AverageDamages}");
        }
    }
}
