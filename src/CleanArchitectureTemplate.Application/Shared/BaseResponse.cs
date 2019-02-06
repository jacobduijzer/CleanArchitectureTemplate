namespace CleanArchitectureTemplate.Application.Shared
{
    public class BaseResponse
    {
        public readonly bool IsSuccessful;

        public readonly string Message;

        public BaseResponse(bool isSuccessful) =>
            IsSuccessful = isSuccessful;

        public BaseResponse(bool isSuccessful, string message)
            : this(isSuccessful) =>
                Message = message;
    }
}
