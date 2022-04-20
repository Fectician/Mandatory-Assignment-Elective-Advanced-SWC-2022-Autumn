using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Creatures.General;
using GameFrameWork.Items;

namespace GameFrameWork.Creatures.Classes
{
    public class Swordmaster: GeneralAttributes
    {
        public Swordmaster() : base(health: 17, movement: 6, strength: 6, speed: 19, skill: 18, luck: 17, defence: 1, resistance: 1, name: "SwordMaster")
        {
        }
    }
}
