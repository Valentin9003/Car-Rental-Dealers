namespace Domain.Exceptions
{
    public class InvalidOptionsExceptions: BaseDomainException
    {
        public InvalidOptionsExceptions()
        {
        }

        public InvalidOptionsExceptions(string error) => this.Error = error;
    }
}
