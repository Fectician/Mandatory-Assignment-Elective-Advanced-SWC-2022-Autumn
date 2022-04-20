using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Creatures.General;
using GameFrameWork.Items;

namespace GameFrameWork.Creatures.Classes
{
    public class Warrior : GeneralAttributes
    {
        public Warrior() : base(health: 26, movement: 5, strength: 11, speed: 9, skill: 14, luck: 7, defence: 9, resistance: 1, name: "Warrior")
        {
        }
    }
}
