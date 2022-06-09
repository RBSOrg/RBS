namespace RBS.Application.Exceptions
{
    public class UserNotFoundException : BaseException
    {

        public UserNotFoundException(int errorCode, string message) : base(errorCode, message)
        {
        }
    }
}
