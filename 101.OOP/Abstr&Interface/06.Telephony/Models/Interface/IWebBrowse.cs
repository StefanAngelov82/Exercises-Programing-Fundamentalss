using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Models.Interface
{
    public interface IWebBrowse
    {
        public string WebSite { get; }

        public void WebBrowsing(); 

    }
}
