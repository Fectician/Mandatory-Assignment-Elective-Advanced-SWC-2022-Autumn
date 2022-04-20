using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.World.WorldObjects
{
    public class Rock : WorldObject
    {
        public Rock()
        {
            Name = "Rock";
            Passable = false;
            Destroyable = true;
            Health = 20;
        }
    }
}
