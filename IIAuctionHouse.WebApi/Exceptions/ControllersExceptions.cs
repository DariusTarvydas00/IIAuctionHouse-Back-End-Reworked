namespace IIAuctionHouse.WebApi.Exceptions
{
    public static class ControllersExceptions
    {
        public const string NullService = "Service cannot be null";
        public const string IdNullOrLess = "Invalid Id";
        public const string NotMatchingId = "Id needs to match in both url and object";
        public const string InvalidName = "Invalid Name";
        public const string MissingSomeInformation = "Missing some information";
        public const string ValueNotInRange = "Value Not In Range";
    }
}