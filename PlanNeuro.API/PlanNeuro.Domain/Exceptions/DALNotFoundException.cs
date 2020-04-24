namespace PlanNeuro.Domain.Exceptions
{
    public class DALNotFoundException : CustomException
    {
        public DALNotFoundException(string message) : base(message) {  }
    }
}
