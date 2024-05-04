namespace LogForUU.Core.Appenders.Contracts
{
    using Formatting.Layouts.Contracts;
    using Models.Contracts;

    public interface IAppender
    {
        public ILayout Layout { get; }
         
        public void AppendMessage(IMessages messages);
    }
}
