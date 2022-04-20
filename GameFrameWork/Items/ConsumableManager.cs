using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Generic;
using GameFrameWork.Items.Templates;

namespace GameFrameWork.Items
{
    public class ConsumableManager : GenericManager<Consumable>
    {
        public ConsumableManager()
        {
            Add(new Consumable("Vulnerary",
                "A medicinal solution used for healing minor wounds. Heals 10 HP on use.", 10, 3));
        }

    }
}
