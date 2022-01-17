namespace IIAuctionHouse.DataAccess.Exceptions
{
    public static class DataAccessExceptions
    {
        public const string NullContext = "Context Cannot be null";
        public const string NotFound = "Entity does not exists or was not created";
        public const string Exists = "Entity Already Exists";
    }
}