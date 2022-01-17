using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.UserDetailModels;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Entities.UserDetailsEntities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class BidRepository: IBidRepository
    {
        private readonly MainDbContext _ctx;

        public BidRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
        }

        public IEnumerable<Bid> FindAll()
        {
            return _ctx.BidsDbSet.Select(sql => new Bid()
            {
                Id = sql.Id,
                
            }).ToList();
        }
        
        public Bid GetById(int id)
        {
            return _ctx.BidsDbSet.Select(sql => new Bid()
            {
                Id = sql.Id,
                BidAmount = sql.BidAmount,
                User = new User()
                {
                    Id = sql.UserSql.Id,
                    FirstName = sql.UserSql.FirstName,
                    LastName = sql.UserSql.LastName
                },
                Forest = new Forest()
                {
                    Id = sql.ForestSql.Id
                }

            }).FirstOrDefault(user => user.Id == id);
            
        }

        public Bid Create(Bid bid)
        {
            var forest = _ctx.ForestsDbSet.FirstOrDefault(sql => 
                sql.ForestUidSql.ForestUidFirstSql.Id == bid.Forest.ForestUid.FirstUid.Id &&
                sql.ForestUidSql.ForestUidSecondSql.Id == bid.Forest.ForestUid.SecondUid.Id &&
                sql.ForestUidSql.ForestUidSecondSql.Id == bid.Forest.ForestUid.SecondUid.Id);
            var user = _ctx.UserDbSet.FirstOrDefault(sql => 
                sql.Id == bid.User.Id);
            if (forest == null || user == null)
            {
                throw new KeyNotFoundException(DataAccessExceptions.NotFound);
            }
            var newBid = new BidSql()
            {
                Id = bid.Id,
                BidAmount = bid.BidAmount,
                UserSqlId = user.Id,
                ForestSqlId = forest.Id
            };
            _ctx.BidsDbSet.Add(newBid);
            _ctx.SaveChanges();
            return new Bid()
            {
                Id = newBid.Id,
                BidAmount = newBid.BidAmount,
                User = new User()
                {
                    Id = newBid.UserSql.Id,
                    FirstName = newBid.UserSql.FirstName,
                    LastName = newBid.UserSql.LastName
                },
                Forest = new Forest()
                {
                    Id = newBid.ForestSql.Id
                }
            };
        }

        public Bid Update(Bid bid)
        {
            //   var entity = _ctx.UserDbSet.Update(new UserSql()
            // {
            //     Id = user.Id,
            //     FirstName = user.FirstName,
            //     LastName = user.LastName,
            //     UserDetailSql = new UserDetailSql()
            //     {
            //         Email = user.UserDetails.Email,
            //         PhoneNumber = user.UserDetails.PhoneNumber,
            //         AddressSql = new AddressSql()
            //         {
            //             Country = user.UserDetails.Address.Country,
            //             City = user.UserDetails.Address.City,
            //             StreetName = user.UserDetails.Address.StreetName,
            //             StreetOrHouseNumber = user.UserDetails.Address.StreetOrHouseNumber
            //         }
            //     },
            //     ForestUIdSqls = user.ForestUIds.Select(uidSql => new ForestUidSql()
            //     {
            //         Id = uidSql.Id,
            //         ForestUidFirstSql = new ForestUidFirstSql()
            //         {
            //             Id = uidSql.FirstUid.Id,
            //             Value = uidSql.FirstUid.Value
            //         },
            //         ForestUidSecondSql = new ForestUidSecondSql()
            //         {
            //             Id = uidSql.SecondUid.Id,
            //             Value = uidSql.SecondUid.Value
            //         },
            //         ForestUidThirdSql = new ForestUidThirdSql()
            //         {
            //             Id = uidSql.ThirdUid.Id,
            //             Value = uidSql.ThirdUid.Value
            //         }
            //     }).ToList(),
            //     BidSqls = user.Bids.Select(bidSql => new BidSql()
            //     {
            //         Id = bidSql.Id,
            //         BidAmount = bidSql.BidAmount,
            //         BidDateTime = bidSql.BidDateTime
            //     }).ToList()
            // }).Entity;
            // _ctx.SaveChanges();
            // return new User()
            // {
            //     Id = entity.Id,
            //     FirstName = entity.FirstName,
            //     LastName = entity.LastName,
            //     UserDetails = new UserDetails()
            //     {
            //         Id = entity.Id,
            //         Email = entity.UserDetailSql.Email,
            //         PhoneNumber = entity.UserDetailSql.PhoneNumber,
            //         Address = new Address()
            //         {
            //             Id = entity.UserDetailSql.Id,
            //             Country = entity.UserDetailSql.AddressSql.Country,
            //             City = entity.UserDetailSql.AddressSql.City,
            //             StreetName = entity.UserDetailSql.AddressSql.StreetName,
            //             StreetOrHouseNumber = entity.UserDetailSql.AddressSql.StreetOrHouseNumber
            //         },
            //     },
            //     ForestUIds = entity.ForestUIdSqls.Select(uidSql => new ForestUid()
            //     {
            //         Id = uidSql.ForestSqlId,
            //         FirstUid = new ForestUidFirst()
            //         {
            //             Id = uidSql.ForestUidFirstSql.Id,
            //             Value = uidSql.ForestUidFirstSql.Value
            //         },
            //         SecondUid = new ForestUidSecond()
            //         {
            //             Id = uidSql.ForestUidSecondSql.Id,
            //             Value = uidSql.ForestUidSecondSql.Value
            //         },
            //         ThirdUid = new ForestUidThird()
            //         {
            //             Id = uidSql.ForestUidThirdSql.Id,
            //             Value = uidSql.ForestUidThirdSql.Value
            //         }
            //     }).ToList(),
            //     Bids = entity.BidSqls.Select(bidSql => new Bid()
            //     {
            //         Id = bidSql.Id,
            //         BidAmount = bidSql.BidAmount,
            //         BidDateTime = bidSql.BidDateTime
            //     }).ToList()
            //  };
            throw new NotImplementedException("Not implemented");
        }

        public Bid Delete(int id)
        {
            var entity = _ctx.BidsDbSet.FirstOrDefault(bid => bid.Id == id);
            if (entity != null) _ctx.Remove(entity);
            _ctx.SaveChanges();
            return entity != null ? new Bid()
            {
                Id = entity.Id,
                BidAmount = entity.BidAmount,
            } : null;
        }
    }
}