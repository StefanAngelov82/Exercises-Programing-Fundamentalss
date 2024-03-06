using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interface;

namespace Telephony.Models
{
    public class Smartphone : StationaryPhone, IWebBrowse
    {       

        public Smartphone(string phoneNumber, string webSite) : base(phoneNumber)
        {
            this.WebSite = webSite;
        }       

        private string webSite;

        public string WebSite
        {
            get { return webSite; }

            private set 
            {
                foreach (var symbol in value)
                {
                    if (char.IsDigit(symbol))
                    {
                        throw new ArgumentException("Invalid URL!");
                    }
                } 

                webSite = value; 
            }
        }

        public override void Calling()
        {
            Console.WriteLine($"Calling... {PhoneNumber}");
        }

        public void WebBrowsing()
        {
            Console.WriteLine($"Browsing: {WebSite}!");
        }
    }
}
