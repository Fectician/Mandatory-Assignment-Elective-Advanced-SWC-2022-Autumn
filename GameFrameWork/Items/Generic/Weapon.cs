using System.Collections.Generic;

namespace GameFrameWork.Items.Templates
{
    public abstract class Weapon : GenericItem
    {
        public int Accuracy;
        public int Critical;
        public int RangeMin;
        public int RangeMax;
        public int DamageType;
        public int WeaponType;
        public int Damage;

        public Weapon(string name, string description, int damage, int accuracy, int critical, int rangemin, int rangemax, int damagetype, int durability)
        {
            Damage = damage;
            Accuracy = accuracy;
            Critical = critical;
            RangeMin = rangemin;
            RangeMax = rangemax;
            Name = name;
            Description = description;
            DamageType = damagetype;
            Durability = durability;
            MaxDurability = durability;
        }
        public override string ToString()
        {
            return $"Name {Name} Description {Description}\n Damage {Damage} Accuracy {Accuracy} Crit {Critical}\n Range {RangeMin}-{RangeMax}\n Durability {Durability}/{MaxDurability}";
        }
        public abstract List<int> WeaponTriangle(int defenderWeaponType);
    }
}