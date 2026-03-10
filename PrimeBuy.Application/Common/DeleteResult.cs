namespace PrimeBuy.Application.Common
{
    public class DeleteResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public DeleteFailureReason? FailureReason { get; set; }
        public int RelatedItemsCount { get; set; }

        public static DeleteResult Successful(string message = "Item deleted successfully.")
        {
            return new DeleteResult { Success = true, Message = message };
        }

        public static DeleteResult Failed(string message, DeleteFailureReason reason, int relatedItemsCount = 0)
        {
            return new DeleteResult
            {
                Success = false,
                Message = message,
                FailureReason = reason,
                RelatedItemsCount = relatedItemsCount
            };
        }
    }

    public enum DeleteFailureReason
    {
        HasProducts,
        HasChildCategories,
        HasBothProductsAndChildren,
        DatabaseConstraintViolation,
        UnknownError
    }
}