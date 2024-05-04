namespace LogForUU.Core.Formatting
{
    using Contracts;
    using Layouts.Contracts;
    using Models.Contracts;

    public class MessageFormatter : IFormatter
    {
        public string Format(IMessages message, ILayout layout)
        {
            return string.Format(layout.Format, message.DateTime, message.ReportLevels.ToString(), message.MassageText);
        }
    }
}
 