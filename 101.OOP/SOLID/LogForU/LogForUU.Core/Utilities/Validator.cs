namespace LogForUU.Core.Utilities
{
    using Exceptions;
    using System.Globalization;
    using System.Text;

    public static class Validator
    {
        private static HashSet<string> _allowedDateTimeFormats =
            new HashSet<string>
            {
                { "MM/dd/yyyy HH:mm:ss tt" },
                { "MM/dd/yyyy HH:mm:ss" }
            };

        public static IReadOnlySet<string> AllowedDateTimeFormats => _allowedDateTimeFormats;



        public static void IsMessageTextValid(string? TextMessage)
        {
            if (string.IsNullOrWhiteSpace(TextMessage) || string.IsNullOrEmpty(TextMessage))
                throw new WrongInputDataException();
        }

        public static void IsDateTimeValid(string? dateTime) 
        {
            bool isDateTimeFormatValid = false;

            foreach (var currentFormat in _allowedDateTimeFormats)
            {                
                bool isCurrentFormat = DateTime.TryParseExact(dateTime,
                                                              currentFormat,
                                                              CultureInfo.InvariantCulture,
                                                              DateTimeStyles.None,
                                                              out DateTime result);

                if (isCurrentFormat)
                {
                    isDateTimeFormatValid = true;
                    break;
                }
            }

            if (!isDateTimeFormatValid)
                throw new WrongInputDataException(
                    $"Provided DateTime format not supported!" +
                    $"\r\nAllowed DataTimes formats are :{ViewAllowedDateTimeFormats()}");            
        }        

        /// <summary>
        /// Formats should be only valid!!!!
        /// </summary>
        /// <param name="validDataTimeFormat"></param>

        public static void AddDataTimeFormat(string validDataTimeFormat)
            => _allowedDateTimeFormats.Add(validDataTimeFormat);
        
        public static void RemoveDataTimeFormat(string validDataTimeFormat)
            => _allowedDateTimeFormats.Remove(validDataTimeFormat);

        public static string ViewAllowedDateTimeFormats()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("   -> ");
            sb.AppendLine(string.Join(", ", AllowedDateTimeFormats));

            return sb.ToString().Trim();
        }        
    }
}
