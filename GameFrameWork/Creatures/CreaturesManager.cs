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
            bool has = Returnlist().Any(x => x.PosX == item.PosX && x.PosY == item.PosY);
            if (!has) { base.internalList.Add(item); }
        }
    }
}
