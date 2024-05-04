namespace LogForUU.Core.Appenders
{

    using Appenders.Contracts;
    using Formatting.Layouts.Contracts;
    using Formatting.Contracts;
    using Models.Contracts;
    using LogForUU.Core.Formatting;

    public class ConsoleAppender : IAppender
    {
        private readonly IFormatter formatter;

        public ConsoleAppender(ILayout layout)
        {
            formatter = new MessageFormatter();
            Layout = layout;
        }        
        
        public ILayout Layout { get; private set; }

        public void AppendMessage(IMessages messages)
        {           
            string output = formatter.Format(messages, Layout);
            Console.WriteLine(output);
        }
            
        
    }
}
