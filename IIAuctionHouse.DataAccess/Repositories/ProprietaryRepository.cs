using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class ProprietaryRepository: IProprietaryRepository
    {
        private MainDbContext _ctx;

        public ProprietaryRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Proprietary> GetAll()
        {
            return _ctx.Proprietaries.Select(p => new Proprietary
            {
                Id = p.Id,
                ProprietaryIdentificationNumber = p.ProprietaryIdentificationNumber
            }).ToList();
        }

        public Proprietary GetById(int id)
        {
            return _ctx.Proprietaries.Select(p => new Proprietary()
            {
                Id = p.Id,
                ProprietaryIdentificationNumber = p.ProprietaryIdentificationNumber
            }).FirstOrDefault(p => p.Id == id);
        }
    }
}