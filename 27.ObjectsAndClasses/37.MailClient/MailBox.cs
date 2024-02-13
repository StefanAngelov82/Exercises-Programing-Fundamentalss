using System.Text;

namespace MailClient
{
    public class MailBox
    {        

        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
            
        }

        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }



        public void  IncomingMail (Mail mail)
        {
            if (Inbox.Count < Capacity)            
                Inbox.Add(mail);      
        }

        public bool DeleteMail(string sender)
        {
            Mail? target = Inbox.FirstOrDefault(x => x.Sender == sender);

            if (target is null)            
                return false;                     

            return Inbox.Remove(target); ;
        }

        public int ArchiveInboxMessages()
        {
            int count = Inbox.Count;

            Archive.AddRange(Inbox);
            Inbox = new List<Mail>();           

            return count; 
        }

        public string GetLongestMessage()
        {
            return Inbox.OrderByDescending(x => x.Body.Length).First().ToString(); 
        }

        public string InboxView()
        {
            StringBuilder Sb = new StringBuilder();

            Sb.AppendLine("Inbox:");

            foreach (Mail mail in Inbox)
                Sb.AppendLine(mail.ToString());   
            
            return Sb.ToString().Trim();
        }
    }
}
