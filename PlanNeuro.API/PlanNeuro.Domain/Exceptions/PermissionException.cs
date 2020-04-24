namespace PlanNeuro.Domain.Exceptions
{
    public class PermissionException : CustomException
    {
        public PermissionException() : base("You don't have a permission") { }
    }
}
