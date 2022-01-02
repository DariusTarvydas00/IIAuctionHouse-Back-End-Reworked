using System;

namespace IIAuctionHouse.Core.Exceptions
{
    public class DataSourceException: Exception
    {
        public DataSourceException(string message): base(message) {}
    }
}