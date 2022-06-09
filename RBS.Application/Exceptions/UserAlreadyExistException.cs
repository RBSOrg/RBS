namespace RBS.Application.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException(int errorCode, string message) : base(errorCode, message)
        {
        }
    }
}
