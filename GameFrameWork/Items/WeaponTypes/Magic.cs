using GameFrameWork.Items.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.Items.WeaponTypes
{
    public class Magic : Weapon
    {
        public Magic(string name = "MAGIC", string description = "MAGIC", int damage = 0, int accuracy = 0, int critical = 0, int rangemin = 1, int rangemax = 2, int damagetype = 2, int durability = 1) : base(name, description, damage, accuracy, critical, rangemin, rangemax, damagetype, durability)
        {
            WeaponType = 4;
        }
        public override List<int> WeaponTriangle(int defenderWeaponType)
        {
            List<int> results = new List<int>();
            switch (defenderWeaponType)
            {
                case 5:
                    results.Add(-1);
                    results.Add(-15);
                    break;
                case 6:
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
