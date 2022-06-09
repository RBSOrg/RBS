namespace RBS.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public ApiError ApiError { get; set; }


        public UserNotFoundException(int errorCode, string message) : base(message)
        {
            ApiError = new ApiError
            {
                Status = errorCode,
                Detail = message
            };
        }
    }
}
