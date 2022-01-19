using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities.TreeTypeEntities;

namespace IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.PlotConverters.TreeTypeConverters
{
    public class TreeConverter
    {
        public Tree Convert(TreeSql treeSql)
        {
            return new Tree()
            {
                Id = treeSql.Id,
                Name = treeSql.Name
            };
        }

        public TreeSql Convert(Tree tree)
        {
            return new TreeSql()
            {
                Id = tree.Id,
                Name = tree.Name
            };
        }
    }
}