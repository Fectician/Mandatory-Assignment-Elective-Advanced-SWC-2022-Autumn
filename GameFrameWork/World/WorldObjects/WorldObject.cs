using System;

namespace GameFrameWork.World.WorldObjects
{
    public class WorldObject
    {
        public string Name;
        public string Color;
        public Boolean Destroyable;
        public int Health;
        public Boolean Passable;
        public Boolean Lootable = false;

    }
}
