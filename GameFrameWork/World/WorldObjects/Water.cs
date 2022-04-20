using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.World.WorldObjects
{
    public class Water: WorldObject
    {
        public Water()
        {
            Name = "Water";
            Passable = false;
        }
    }
}
