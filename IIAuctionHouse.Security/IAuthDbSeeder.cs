namespace IIAuctionHouse.Security
{
    public interface IAuthDbSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}