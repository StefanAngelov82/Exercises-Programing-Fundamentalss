namespace LogForUU.Core.Models.Contracts
{
    using Enums;

    public interface IMessages
    {
        public string MassageText { get;}
        public string DateTime{ get;}
        public ReportLevel ReportLevels { get;}
    }
}
