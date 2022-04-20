using GameFrameWork.Items.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.Items.WeaponTypes
{
    public class Bow : Weapon
    {
        public Bow(string name = "BOW", string description = "BOW", int damage = 0, int accuracy = 0, int critical = 0, int rangemin = 2, int rangemax = 2, int damagetype = 1, int durability = 1) : base(name, description, damage, accuracy, critical, rangemin, rangemax, damagetype, durability)
        {
            WeaponType = 7;
        }
        public override List<int> WeaponTriangle(int defenderWeaponType)
        {
            List<int> results = new List<int>();
            switch (defenderWeaponType)
            {
                default:
                    results.Add(0);
                    results.Add(0);
                    break;
            }
            return results;
        }
    }
}
