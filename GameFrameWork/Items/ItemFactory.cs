using GameFrameWork.Items.Templates;
using GameFrameWork.Items.WeaponTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.Items
{
    public abstract class AbstractCreator
    {
        public abstract Weapon CreateWeapon(string name, string description, int damage, int accuracy, int critical, int rangemin, int rangemax, int damagetype, int durability);
    }
    public class SwordCreator : AbstractCreator
    {
        /// <summary>
        /// Creates a Sword. Put this object into the WeaponsManager to use it in the "game".
        /// </summary>
        public override Weapon CreateWeapon(string name = "Sword", string description = "Custom Sword", int damage = 0, int accuracy = 0, int critical = 0, int rangemin = 1, int rangemax = 1, int damagetype = 1, int durability = 1)
        {
            return new Sword(name, description, damage, accuracy, critical, rangemin, rangemax, damagetype, durability);
        }
    }

    public class AxeCreator : AbstractCreator
    {
        /// <summary>
        /// Creates an Axe. Put this object into the WeaponsManager to use it in the "game".
        /// </summary>
        public override Weapon CreateWeapon(string name = "Axe", string description = "Custom Axe", int damage = 0, int accuracy = 0, int critical = 0, int rangemin = 1, int rangemax = 1, int damagetype = 1, int durability = 1)
        {
            return new Axe(name, description, damage, accuracy, critical, rangemin, rangemax, damagetype, durability);
        }
    }
    public class LanceCreator : AbstractCreator
    {
        /// <summary>
        /// Creates a Lance. Put this object into the WeaponsManager to use it in the "game".
        /// </summary>
        public override Weapon CreateWeapon(string name = "Lance", string description = "Custom Lance", int damage = 0, int accuracy = 0, int critical = 0, int rangemin = 1, int rangemax = 1, int damagetype = 1, int durability = 1)
        {
            return new Lance(name, description, damage, accuracy, critical, rangemin, rangemax, damagetype, durability);
        }
    }
}
