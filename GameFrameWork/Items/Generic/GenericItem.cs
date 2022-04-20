using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.Items.Templates
{
    public abstract class GenericItem
    {
        public string Name;
        public string Description;
        public int MaxDurability;
        public int Durability;
        /// <summary>
        /// Makes a shallowcopy of the object, so you can "copy" the attributes of this object to another object, without having them "linked".
        /// By "linked" I mean changing values of either object does NOT change the values of the other.
        /// </summary>
        /// <returns></returns>
        public GenericItem ShallowCopy()
        {
            return (GenericItem) this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"Name {Name} Description {Description}\n Durability {Durability}/{MaxDurability}\n" ;
        }
    }
}
