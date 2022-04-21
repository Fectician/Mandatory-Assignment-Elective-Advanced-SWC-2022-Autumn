using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.Generic
{
    public abstract class GenericManager<T>
    {
        protected List<T> internalList;
        protected GenericManager()
        {
            internalList = new List<T>();
        }

        public virtual void Add(T item)
        {
            internalList.Add(item);
        }

        public void AddRange(T[] item)
        {
            internalList.AddRange(item);
        }

        public void Remove(T item)
        {
            internalList.Remove(item);
        }
        
        public List<T> Returnlist()
        {
            return new List<T>(internalList);
        }
        
        public T Find(int i)
        {
            return Returnlist()[i];
        }
    }
}
