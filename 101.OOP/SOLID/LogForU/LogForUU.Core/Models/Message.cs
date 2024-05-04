namespace LogForUU.Core.Models
{
    using Enums;
    using Contracts;
    using Utilities;

    public class Message : IMessages
    {
        private string? _messageText;
        private string? _dataTime;

        public Message(string messageText, string dateTime, ReportLevel reportLevel) 
        {
            MassageText = messageText;
            DateTime = dateTime;
            ReportLevels = reportLevel;
        }

        public string MassageText 
        { 
            get => _messageText!; 
            private set
            {
                Validator.IsMessageTextValid(value);
                
                _messageText = value;
            }
    }
        public string DateTime
        {
            get => _dataTime!;
            private set
            {
                Validator.IsDateTimeValid(value);

                _dataTime = value;
            }
        }
        public ReportLevel ReportLevels { get; }
    }

}
