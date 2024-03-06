using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Models.Interface
{
    public interface IPhoneCall
    {
        public string PhoneNumber { get;}
        public void Calling();
    }
}
