using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;

namespace IIAuctionHouse.DataAccess.Converters.ForestDetailConverters
{
    public class ForestGroupConverter
    {
        public ForestGroup Convert(ForestGroupSql forestGroupSql)
        {
            if (forestGroupSql != null) 
                return new ForestGroup()
            {
                Id = forestGroupSql.Id,
                Name = forestGroupSql.Name,
                Forests = forestGroupSql.ForestSqls != null ? forestGroupSql.ForestSqls.Select(sql =>new Forest()
                {
                    Id = sql?.Id ?? 0,
                    ForestLocation = new ForestLocation()
                    {
                        Id = sql.ForestLocationSql.Id,
                        GeoLocationX = sql.ForestLocationSql.GeoLocationX,
                        GeoLocationY = sql.ForestLocationSql.GeoLocationY
                    },
                    ForestryEnterprise = sql.ForestryEnterpriseSql != null ? new ForestryEnterprise()
                    {
                        Id = sql.ForestryEnterpriseSql?.Id ?? 0,
                        Name = sql.ForestryEnterpriseSql.Name
                    } : null
                } ).ToList() : null,
            };
            return null;
        }

        public ForestGroupSql Convert(ForestGroup forestGroup)
        {
            if (forestGroup != null) 
                return new ForestGroupSql()
            {
                Id = forestGroup.Id,
                Name = forestGroup.Name
            }; 
            return null;
        }
    }
}