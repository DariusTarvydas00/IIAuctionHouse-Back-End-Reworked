using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.TreeTypeEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.TreeTypeEntities.TTEntities;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.ITreeTypeRepositories.TTRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.TreeTypeRepositories.TTRepositories
{
    public class TreeRepository: ITreeRepository
    {
        private readonly MainDbContext _ctx;

        public TreeRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException("Context Can Not Be Null");
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
            var tree = _ctx.TreeDbSet.FirstOrDefault(sql => sql.Id == id);
            if (tree == null) return null;
            return new Tree()
            {
                Id = tree.Id,
                Name = tree.Name
            };
        }


        public Tree Create(Tree tree)
        {
            var treeSql = _ctx.TreeDbSet.FirstOrDefault(sql => sql.Id == tree.Id);
            if (treeSql != null)
                if (treeSql.Name.ToLower().Equals(tree.Name.ToLower())) throw new Exception("Tree Name Already Exists");
            var newTree = _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = tree.Name
            }).Entity;
            _ctx.SaveChanges();
            return new Tree()
            {
                Id = newTree.Id,
                Name = newTree.Name
            };
        }

        public Tree Update(Tree tree)
        {
            var treeSql = _ctx.TreeDbSet.AsNoTracking().FirstOrDefault(sql => sql.Id == tree.Id);
            if (treeSql == null) throw new Exception("Tree To Update Does Not Exist");
            if (treeSql.Name.ToLower().Equals(tree.Name.ToLower())) throw new Exception("Tree Name Already Exists");
            var treeUpdate = _ctx.TreeDbSet.Update(new TreeSql()
            {
                Id = tree.Id,
                Name = tree.Name
            }).Entity;
            _ctx.SaveChanges();
            return new Tree()
            {
                Id = treeUpdate.Id,
                Name = treeUpdate.Name
            };
        }

        public Tree Delete(int id)
        {
            try
            {
                var treeSql = _ctx.TreeDbSet.FirstOrDefault(fe => fe.Id == id);
                if (treeSql == null) throw new Exception("Tree Not Found ");
                _ctx.TreeDbSet.Remove(treeSql);
                _ctx.SaveChanges();
                return new Tree()
                {
                    Id = treeSql.Id,
                    Name = treeSql.Name
                };
            }
            catch (Exception)
            {
                throw new Exception("Tree Can Not be Deleted! ");
            }
        }

    }
}