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
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly MainDbContext _ctx;

        public UserRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<User> FindAll()
        {
            return _ctx.UserDbSet.Select(sql => new User()
            {
                Id = sql.Id,
                FirstName = sql.FirstName,
                LastName = sql.LastName,
            }).ToList();
        }
        
        public User GetById(int id)
        {
            return _ctx.UserDbSet.Select(sql => new User()
            {
                Id = sql.Id,
                FirstName = sql.FirstName,
                LastName = sql.LastName,
                UserDetails = new UserDetails()
                {
                    Id = sql.Id,
                    Email = sql.UserDetailSql.Email,
                    PhoneNumber = sql.UserDetailSql.PhoneNumber,
                    Address = new Address()
                    {
                        Id = sql.UserDetailSql.Id,
                        Country = sql.UserDetailSql.AddressSql.Country,
                        City = sql.UserDetailSql.AddressSql.City,
                        StreetName = sql.UserDetailSql.AddressSql.StreetName,
                        StreetOrHouseNumber = sql.UserDetailSql.AddressSql.StreetOrHouseNumber
                    },
                },
                ForestUIds = sql.ForestUIdSqls.Select(uidSql => new ForestUid()
                {
                    Id = uidSql.Id,
                    FirstUid = new ForestUidFirst()
                    {
                        Id = uidSql.ForestUidFirstSql.Id,
                        Value = uidSql.ForestUidFirstSql.Value
                    },
                    SecondUid = new ForestUidSecond()
                    {
                        Id = uidSql.ForestUidSecondSql.Id,
                        Value = uidSql.ForestUidSecondSql.Value
                    },
                    ThirdUid = new ForestUidThird()
                    {
                        Id = uidSql.ForestUidThirdSql.Id,
                        Value = uidSql.ForestUidThirdSql.Value
                    }
                }).ToList(),
                Bids = sql.BidSqls.Select(bidSql => new Bid()
                {
                    Id = bidSql.Id,
                    BidAmount = bidSql.BidAmount,
                    BidDateTime = bidSql.BidDateTime
                }).ToList()

            }).FirstOrDefault(user => user.Id == id);
            
        }

        public User Create(User user)
        {
            var newUser = new UserSql()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserDetailSql = new UserDetailSql()
                {
                    Email = user.UserDetails.Email,
                    PhoneNumber = user.UserDetails.PhoneNumber,
                    AddressSql = new AddressSql()
                    {
                        Country = user.UserDetails.Address.Country,
                        City = user.UserDetails.Address.City,
                        StreetName = user.UserDetails.Address.StreetName,
                        StreetOrHouseNumber = user.UserDetails.Address.StreetOrHouseNumber
                    }
                }
            };
            _ctx.UserDbSet.Add(newUser);
            _ctx.SaveChanges();
            return new User()
            {
                Id = newUser.Id,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                UserDetails = new UserDetails()
                {
                    Email = newUser.UserDetailSql.Email,
                    PhoneNumber = newUser.UserDetailSql.PhoneNumber,
                    Address = new Address()
                    {
                        Country = newUser.UserDetailSql.AddressSql.Country,
                        City = newUser.UserDetailSql.AddressSql.City,
                        StreetName = newUser.UserDetailSql.AddressSql.StreetName,
                        StreetOrHouseNumber = newUser.UserDetailSql.AddressSql.StreetOrHouseNumber
                    }
                }
            };
        }

        public User Update(User user)
        {
              var entity = _ctx.UserDbSet.Update(new UserSql()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserDetailSql = new UserDetailSql()
                {
                    Email = user.UserDetails.Email,
                    PhoneNumber = user.UserDetails.PhoneNumber,
                    AddressSql = new AddressSql()
                    {
                        Country = user.UserDetails.Address.Country,
                        City = user.UserDetails.Address.City,
                        StreetName = user.UserDetails.Address.StreetName,
                        StreetOrHouseNumber = user.UserDetails.Address.StreetOrHouseNumber
                    }
                },
                ForestUIdSqls = user.ForestUIds.Select(uidSql => new ForestUidSql()
                {
                    Id = uidSql.Id,
                    ForestUidFirstSql = new ForestUidFirstSql()
                    {
                        Id = uidSql.FirstUid.Id,
                        Value = uidSql.FirstUid.Value
                    },
                    ForestUidSecondSql = new ForestUidSecondSql()
                    {
                        Id = uidSql.SecondUid.Id,
                        Value = uidSql.SecondUid.Value
                    },
                    ForestUidThirdSql = new ForestUidThirdSql()
                    {
                        Id = uidSql.ThirdUid.Id,
                        Value = uidSql.ThirdUid.Value
                    }
                }).ToList(),
                BidSqls = user.Bids.Select(bidSql => new BidSql()
                {
                    Id = bidSql.Id,
                    BidAmount = bidSql.BidAmount,
                    BidDateTime = bidSql.BidDateTime
                }).ToList()
            }).Entity;
            _ctx.SaveChanges();
            return new User()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserDetails = new UserDetails()
                {
                    Id = entity.Id,
                    Email = entity.UserDetailSql.Email,
                    PhoneNumber = entity.UserDetailSql.PhoneNumber,
                    Address = new Address()
                    {
                        Id = entity.UserDetailSql.Id,
                        Country = entity.UserDetailSql.AddressSql.Country,
                        City = entity.UserDetailSql.AddressSql.City,
                        StreetName = entity.UserDetailSql.AddressSql.StreetName,
                        StreetOrHouseNumber = entity.UserDetailSql.AddressSql.StreetOrHouseNumber
                    },
                },
                ForestUIds = entity.ForestUIdSqls.Select(uidSql => new ForestUid()
                {
                    Id = uidSql.Id,
                    FirstUid = new ForestUidFirst()
                    {
                        Id = uidSql.ForestUidFirstSql.Id,
                        Value = uidSql.ForestUidFirstSql.Value
                    },
                    SecondUid = new ForestUidSecond()
                    {
                        Id = uidSql.ForestUidSecondSql.Id,
                        Value = uidSql.ForestUidSecondSql.Value
                    },
                    ThirdUid = new ForestUidThird()
                    {
                        Id = uidSql.ForestUidThirdSql.Id,
                        Value = uidSql.ForestUidThirdSql.Value
                    }
                }).ToList(),
                Bids = entity.BidSqls.Select(bidSql => new Bid()
                {
                    Id = bidSql.Id,
                    BidAmount = bidSql.BidAmount,
                    BidDateTime = bidSql.BidDateTime
                }).ToList()
             };
        }

        public User Delete(int id)
        {
            var entity = _ctx.UserDbSet.FirstOrDefault(user => user.Id == id);
            if (entity != null) _ctx.Remove(entity);
            _ctx.SaveChanges();
            return entity != null ? new User()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
            } : null;
        }
    }
}