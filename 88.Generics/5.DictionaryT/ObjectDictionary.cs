
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryT
{
    public class ObjectDictionary<TKeys, TValues>
    {
        private int index = 0;
        private TKeys[] key;
        private TValues[] values;

        public ObjectDictionary(int capacity)
        {
            this.key = new TKeys[capacity];
            this.values = new TValues[capacity];
        }


        public void AddData(TKeys key, TValues values)
        {
            this.key[index] = key;
            this.values[index] = values;    
            index++;
        }

        public TValues GetData(TKeys key)
        {
            var index = Array.IndexOf(this.key, key);

            return this.values[index];
        }
    }
}
