namespace LogForUU.Core.Exceptions
{
    internal class WrongInputDataException : Exception
    {
        private const string DefaultMessage = "Message text can not be NULL or Empty!";

        public WrongInputDataException() 
            : base(DefaultMessage) 
        {
        }

        public WrongInputDataException(string message)
             : base(message)
        {
        }
    }
}
