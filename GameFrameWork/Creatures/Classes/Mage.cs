using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Creatures.General;
using GameFrameWork.Items;

namespace GameFrameWork.Creatures.Classes
{
    public class Mage : GeneralAttributes
    {
        public Mage() : base(health: 12, movement: 5, strength: 1, magic: 13, speed: 14, skill: 11, luck: 2, defence: 1, resistance: 6, name: "Mage")
        {
            
        }
    }
}
