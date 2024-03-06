using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interface;

namespace Telephony.Models
{
    public class StationaryPhone : IPhoneCall
    {
        private string phoneNumber;

        public StationaryPhone(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }

            private set 
            {
                foreach (var symbol in value)
                {
                    if (char.IsLetter(symbol))
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }

                phoneNumber = value; 
            }
        }

        public virtual void Calling()
        {
            Console.WriteLine($"Dialing... {PhoneNumber}");
        }
    }
}
