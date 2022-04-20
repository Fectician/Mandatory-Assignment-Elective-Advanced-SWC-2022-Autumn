using GameFrameWork.Generic;
using GameFrameWork.Items.Templates;
using GameFrameWork.Items.WeaponTypes;

namespace GameFrameWork.Items
{
    public class WeaponsManager : GenericManager<Weapon>
    {
        public WeaponsManager()
        {
            AddRange(new Weapon[]
            {
                new Axe(name:"Iron Axe", description: "Axe of Iron", damage: 8, accuracy: 65, durability: 45),
                new Sword(name:"Iron Sword", description: "Sword of Iron", damage: 5, accuracy: 85, durability: 46),
                new Lance(name:"Iron Lance", description: "Lance of Iron", damage: 7, accuracy: 70, durability: 45),
                new Magic(name:"Fire Tome", description: "Tome of Fire", damage: 5, accuracy: 90, durability: 40),
                new Bow(name:"Iron Bow", description: "Bow of Iron", damage: 6, accuracy: 80, durability: 45),
                new Sword(name:"Killing Edge", description: "Deadly Blade designed for critical hits.", damage: 9, accuracy: 80, durability: 20, critical: 30)
            });
        }
    }
}
