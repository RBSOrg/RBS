namespace RBS.Application.Exceptions
{
    public class BaseException : Exception
    {
        public ApiError ApiError { get; set; }
        private string ErrorMessage { get; set; }

        protected BaseException(int errorCode, string message)
            : base(message)
        {
            ApiError = new ApiError
            {
                Status = errorCode,
                Detail = message
            };
            ErrorMessage = message;
        }
    }
}