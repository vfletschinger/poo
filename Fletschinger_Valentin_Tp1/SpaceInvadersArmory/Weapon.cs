namespace SpaceInvadersArmory
{
    public class Weapon : IWeapon
    {
        public string Name { get; }
        public double MinDamage { get; }
        public double MaxDamage { get; }
        public EWeaponType Type { get; }

        // Temps de rechargement en nombre de tours (doublé pour les armes explosives)
        public int ReloadTime { get; }

        // Nombre de tours restant avant que l'arme puisse tirer
        public int TimeBeforeReload { get; private set; }

        public double AverageDamage => (MinDamage + MaxDamage) / 2;

        public bool IsReady => TimeBeforeReload == 0;

        public Weapon(string Name, double MinDamage, double MaxDamage, EWeaponType Type, int ReloadTime)
        {
            this.Name = Name;
            this.MinDamage = MinDamage;
            this.MaxDamage = MaxDamage;
            this.Type = Type;
            this.ReloadTime = Type == EWeaponType.Explosive ? ReloadTime * 2 : ReloadTime;
            this.TimeBeforeReload = this.ReloadTime;
        }

        public void DecrementReload()
        {
            if (TimeBeforeReload > 0)
            {
                TimeBeforeReload--;
            }
        }

        public double Shoot()
        {
            if (!IsReady)
            {
                return 0;
            }

            double damage = MinDamage + Random.Shared.NextDouble() * (MaxDamage - MinDamage);

            switch (Type)
            {
                case EWeaponType.Direct:
                    // 1 chance sur 10 de rater
                    if (Random.Shared.NextDouble() < 0.1)
                    {
                        damage = 0;
                    }
                    break;

                case EWeaponType.Explosive:
                    // Dégâts doublés, mais 1 chance sur 4 de rater
                    damage *= 2;
                    if (Random.Shared.NextDouble() < 0.25)
                    {
                        damage = 0;
                    }
                    break;

                case EWeaponType.Guided:
                    // Touche toujours, avec les dégâts minimums
                    damage = MinDamage;
                    break;
            }

            TimeBeforeReload = ReloadTime;
            return damage;
        }

        public override string ToString()
        {
            return $"{Name} ({Type}) : {MinDamage}-{MaxDamage} dégâts, rechargement {ReloadTime} tour(s)";
        }
    }
}
