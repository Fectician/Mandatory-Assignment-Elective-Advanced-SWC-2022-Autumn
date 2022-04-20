using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Creatures.General;
using GameFrameWork.Generic;
using GameFrameWork.World;

namespace GameFrameWork.Creatures
{
    class CreaturesManager : GenericManager<CharacterAndPosition>
    {
        public override void Add(CharacterAndPosition item) 
        {
            foreach (CharacterAndPosition Character in Returnlist())
            {
                if (item.PosX == Character.PosX && item.PosY == Character.PosY) { return; }
            }
            base.internalList.Add(item);
        }
    }
}
