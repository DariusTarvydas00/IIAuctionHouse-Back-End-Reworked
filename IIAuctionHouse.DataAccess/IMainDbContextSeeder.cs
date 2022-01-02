namespace IIAuctionHouse.DataAccess
{
    public interface IMainDbContextSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}