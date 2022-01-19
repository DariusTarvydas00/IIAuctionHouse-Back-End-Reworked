using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities.TreeTypeEntities;

namespace IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.PlotConverters.TreeTypeConverters
{
    public class TreeTypeConverter
    {
        public TreeType Convert(TreeTypeSql treeTypeSql)
        {
            return new TreeType()
            {
                Id = treeTypeSql.Id,
                Percentage = new Percentage()
                {
                    Id = treeTypeSql.PercentageSql.Id,
                    Value = treeTypeSql.PercentageSql.Value
                },
                Tree = new Tree()
                {
                    Id = treeTypeSql.TreeSql.Id,
                    Name = treeTypeSql.TreeSql.Name
                }
            };
        }

        public TreeTypeSql Convert(TreeType treeType)
        {
            return new TreeTypeSql()
            {
                Id = treeType.Id,
                PercentageSql = new PercentageSql()
                {
                    Id = treeType.Percentage.Id,
                    Value = treeType.Percentage.Value
                },
                TreeSql = new TreeSql()
                {
                    Id = treeType.Tree.Id,
                    Name = treeType.Tree.Name
                }
            };
        }
    }
}