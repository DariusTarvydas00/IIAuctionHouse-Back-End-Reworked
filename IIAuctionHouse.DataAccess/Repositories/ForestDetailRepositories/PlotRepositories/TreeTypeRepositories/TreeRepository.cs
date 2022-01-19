using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.PlotConverters.TreeTypeConverters;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.PlotRepositories.TreeTypeRepositories
{
    public class TreeRepository: ITreeRepository
    {
        private readonly MainDbContext _ctx;
        private readonly TreeConverter _treeConverter;

        public TreeRepository(MainDbContext ctx, TreeConverter treeConverter)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _treeConverter = treeConverter ?? throw new NullReferenceException(DataAccessExceptions.NullConverter);
        }

        public IEnumerable<Tree> FindAll()
        {
            return _ctx.TreeDbSet.OrderBy(sql => sql.Name).Select(tree => new Tree()
            {
                Id = tree.Id,
                Name = tree.Name,
            }).ToList();
        }
        
        public Tree GetById(int id)
        {
            return _ctx.TreeDbSet.Select(tree => new Tree()
            {
                Id = tree.Id,
                Name = tree.Name,
            }).FirstOrDefault(tree => tree.Id == id);
        }


        public Tree Create(Tree tree)
        {
            var exists = _ctx.TreeDbSet.Any(sql => sql.Name.ToLower() == tree.Name.ToLower());
            if (exists) throw new InvalidOperationException(DataAccessExceptions.EntityExists);
            var treeEntitySql = _treeConverter.Convert(tree);
            _ctx.TreeDbSet.Add(treeEntitySql);
            _ctx.SaveChanges();
            return _treeConverter.Convert(treeEntitySql);
        }

        public Tree Update(Tree tree)
        {
            var check = _ctx.TreeDbSet.AsNoTracking().FirstOrDefault(sql => sql.Id == tree.Id);
            if (check == null) throw new InvalidOperationException(DataAccessExceptions.NotFound);
            if (check.Name.ToLower().Equals(tree.Name.ToLower())) throw new InvalidOperationException(DataAccessExceptions.EntityExists);
            var treeUpdate = _ctx.TreeDbSet.Update(_treeConverter.Convert(tree)).Entity;
            _ctx.SaveChanges();
            return _treeConverter.Convert(treeUpdate);
        }

        public Tree Delete(int id)
        {
            var treeSql = _ctx.TreeDbSet.FirstOrDefault(fe => fe.Id == id);
            if (treeSql == null) throw new InvalidOperationException(DataAccessExceptions.NotFound);
            _ctx.TreeDbSet.Remove(treeSql);
            _ctx.SaveChanges();
            return _treeConverter.Convert(treeSql);
        }

    }
}