using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities.TreeTypeEntities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.PlotRepositories.TreeTypeRepositories
{
    public class TreeRepository: ITreeRepository
    {
        private readonly MainDbContext _ctx;

        public TreeRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            
        }

        public IEnumerable<Tree> FindAll()
        {
            return _ctx.TreeDbSet.OrderBy(sql => sql.Name).Select(tree => new Tree()
            {
                Id = tree.Id,
                Name = tree.Name,
            }).ToList();
        }

        public Tree Create(Tree tree)
        {
            var entity = _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = tree.Name,
            }).Entity;
            _ctx.SaveChanges();
            return new Tree()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public Tree Update(Tree updateTree)
        {
            var newTree = new TreeSql()
            {
                Id = updateTree.Id,
                Name = updateTree.Name
            };
            var check =_ctx.TreeDbSet.SingleOrDefault(sql => sql.Id == updateTree.Id);
            if (check != null)
            {
                _ctx.TreeDbSet.Update(newTree);
            }
            else
            {
                _ctx.TreeDbSet.Add(newTree);
            }
            _ctx.TreeDbSet.Update(newTree);
            _ctx.SaveChanges();
            return new Tree()
            {
                Id = newTree.Id,
                Name = newTree.Name
            };
        }

        public Tree Delete(int id)
        {
            var entity = _ctx.TreeDbSet.FirstOrDefault(tree => tree.Id == id);
            if (entity != null) _ctx.TreeDbSet.Remove(entity);
            _ctx.SaveChanges();
            return entity != null ? new Tree()
            {
                Id = entity.Id,
                Name = entity.Name,
            }: null;
        }

    }
}