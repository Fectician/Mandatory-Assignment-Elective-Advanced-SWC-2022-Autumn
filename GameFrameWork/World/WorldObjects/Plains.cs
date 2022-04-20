using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.World.WorldObjects
{
    public class Plains : WorldObject
    {
        public Plains()
        {
            Name = "Plains";
            Passable = true;
        }
    }
}
