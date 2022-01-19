namespace IIAuctionHouse.DataAccess.Exceptions
{
    public static class DataAccessExceptions
    {
        public const string NullContext = "Context Cannot be null";
        public const string NotFound = "Entity does not exists";
        public const string EntityExists = "Entity Already Exists";
        public const string NullConverter = "Converter Cannot Be Null";
        public const string DeleteProcessStopped = "Deletion Restricted!";
    }
}