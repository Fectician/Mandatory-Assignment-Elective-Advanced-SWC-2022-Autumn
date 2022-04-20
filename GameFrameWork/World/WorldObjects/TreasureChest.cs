using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Items.Templates;
using Microsoft.VisualBasic;

namespace GameFrameWork.World.WorldObjects
{
    public class TreasureChest : WorldObject
    {
        public GenericItem _containedItem;
        public TreasureChest(GenericItem containeditem)
        {
            Name = "Treasure Chest";
            Destroyable = false;
            Passable = true;
            Lootable = true;
            _containedItem = containeditem;
        }

        public GenericItem Open()
        {
            GenericItem item = _containedItem;
            Lootable = false;
            return item;
        }
    }
}
