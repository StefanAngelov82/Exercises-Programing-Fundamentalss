namespace LogForUU.Core.Formatting.Contracts
{
    using Layouts.Contracts;
    using Models.Contracts;

    public interface IFormatter
    {
        string Format(IMessages message, ILayout layout);
    }
}
