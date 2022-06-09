namespace RBS.Application.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public ApiError ApiError { get; set; }


        public UserAlreadyExistException(int errorCode, string message) : base(message)
        {
            ApiError = new ApiError
            {
                Status = errorCode,
                Detail = message
            };
        }
    }
}
