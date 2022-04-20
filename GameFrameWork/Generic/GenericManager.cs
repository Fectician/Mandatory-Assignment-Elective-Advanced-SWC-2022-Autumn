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
        
        /*
        /// <summary>
        /// I stole this function from the internet, to help me make deep copies of items in the managers, instead of just copying them over (doesn't work so good with durability, durability decreases for 1 character's weapon will affect other weapons of the same type.)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public T Find(int i)
        {
            T item = Returnlist()[i];
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
        */
    }
}
