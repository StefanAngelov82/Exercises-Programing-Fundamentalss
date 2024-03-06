using Telephony.Models;
using Telephony.Models.Interface;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries );

            string[] webSites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            foreach ( string phoneNumber in phoneNumbers )
            {
                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        IPhoneCall phoneCall = new StationaryPhone(phoneNumber);
                        phoneCall.Calling();
                    }
                    else
                    {
                        IPhoneCall phoneCall = new Smartphone(phoneNumber,"");
                        phoneCall.Calling();
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var site in webSites)
            {

                try
                {
                    IWebBrowse webBrowser = new Smartphone("", site);
                    webBrowser.WebBrowsing();
                }
                catch (Exception ex )
                {

                    Console.WriteLine(ex.Message);
                }                              
            }
        }
    }
}