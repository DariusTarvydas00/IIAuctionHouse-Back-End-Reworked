using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;

namespace IIAuctionHouse.DataAccess.Converters.ForestDetailConverters
{
    public class ForestryEnterpriseConverter
    {
        public ForestryEnterprise Convert(ForestryEnterpriseSql forestryEnterpriseSql)
        {
            if (forestryEnterpriseSql != null)
                return new ForestryEnterprise()
                {
                    Id = forestryEnterpriseSql?.Id ?? 0,
                    Name = forestryEnterpriseSql.Name,
                    Forests = forestryEnterpriseSql.ForestSqls != null ? forestryEnterpriseSql.ForestSqls.Select(sql =>new Forest()
                    {
                        Id = sql?.Id ?? 0,
                        ForestLocation = new ForestLocation()
                        {
                            Id = sql.ForestLocationSql.Id,
                            GeoLocationX = sql.ForestLocationSql.GeoLocationX,
                            GeoLocationY = sql.ForestLocationSql.GeoLocationY
                        },
                        ForestGroup = sql.ForestGroupSql != null ? new ForestGroup()
                        {
                            Id = sql.ForestGroupSql?.Id ?? 0,
                            Name = sql.ForestGroupSql.Name
                        } : null
                    } ).ToList() : null
                };
            return null;
        }

        public ForestryEnterpriseSql Convert(ForestryEnterprise forestryEnterprise)
        {
            if (forestryEnterprise != null)
                return new ForestryEnterpriseSql()
                {
                    Id = forestryEnterprise?.Id ?? 0,
                    Name = forestryEnterprise.Name,
                };
            return null;
        }
    }
}