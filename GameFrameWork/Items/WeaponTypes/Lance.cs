using GameFrameWork.Items.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.Items.WeaponTypes
{
    public class Lance : Weapon
    {
        public Lance(string name = "LANCE", string description = "LANCE", int damage = 0, int accuracy = 0, int critical = 0, int rangemin = 1, int rangemax = 1, int damagetype = 1, int durability = 1) : base(name, description, damage, accuracy, critical, rangemin, rangemax, damagetype, durability)
        {
            WeaponType = 3;
        }
        public override List<int> WeaponTriangle(int defenderWeaponType)
        {
            List<int> results = new List<int>();
            switch (defenderWeaponType)
            {
                case 1:
                    results.Add(-1);
                    results.Add(-15);
                    break;
                case 2:
                    results.Add(1);
                    results.Add(15);
                    break;
                default:
                    results.Add(0);
                    results.Add(0);
                    break;
            }
            return results;
        }
    }
}
