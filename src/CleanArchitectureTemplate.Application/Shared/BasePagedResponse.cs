namespace CleanArchitectureTemplate.Application.Shared
{
    public class BasePagedResponse : BaseResponse
    {
        public readonly bool HasPreviousPage;
        public readonly bool HasNextPage;
        public readonly int CurrentPageNumber;

        public BasePagedResponse(
            bool hasPreviousPage,
            bool hasNextPage,
            int currentPageNumber
            )
            : base(true)
        {
            HasPreviousPage = hasPreviousPage;
            HasNextPage = hasNextPage;
            CurrentPageNumber = currentPageNumber;
        }

        public BasePagedResponse(bool isSuccessful)
            : base(isSuccessful)
        { }


        public BasePagedResponse(bool isSuccessful, string message)
            : base(isSuccessful, message)
        { }
    }
}
