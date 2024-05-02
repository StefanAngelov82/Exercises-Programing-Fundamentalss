using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Wild_Farm2.IO.Interface
{
    public interface IWrite
    {
        public void Write(object obj);
            
    }
}
