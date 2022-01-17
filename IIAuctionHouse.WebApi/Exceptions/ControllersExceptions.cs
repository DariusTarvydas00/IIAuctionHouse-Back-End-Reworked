namespace IIAuctionHouse.WebApi.Exceptions
{
    public static class ControllersExceptions
    {
        public const string ServiceIsNull = "Controller is not initialized";
        public const string IdNullOrLess = "Wrond Id";
        public const string NotMatchingId = "Id needs to match in both url and object";
        public const string InvalidName = "Invalid Name";
        public const string MissingSomeInformation = "Missing some information";
    }
}