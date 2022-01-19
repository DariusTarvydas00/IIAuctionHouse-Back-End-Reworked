using System;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.PlotRepositories.TreeTypeRepositories
{
    public class TreeTypeRepository: ITreeTypeRepository
    {
        
        private readonly MainDbContext _ctx;
        private readonly ITreeRepository _treeRepository;
        private readonly IPercentageRepository _percentageRepository;

        public TreeTypeRepository(MainDbContext ctx, ITreeRepository treeRepository, IPercentageRepository percentageRepository)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _treeRepository = treeRepository ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _percentageRepository = percentageRepository ?? throw new NullReferenceException(DataAccessExceptions.NullContext);

        }
        
    }
}