namespace PlanNeuro.Domain.Exceptions
{
    public class DBException : CustomException
    {
        public DBException(string message) : base(message) { }
    }
}
