using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities.TreeTypeEntities;

namespace IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.PlotConverters.TreeTypeConverters
{
    public class TreeTypeConverter
    {
        public TreeType Convert(TreeTypeSql treeTypeSql)
        {
            if (treeTypeSql != null)
                return new TreeType()
                {
                    Id = treeTypeSql?.Id ?? 0,
                    Percentage = new Percentage()
                    {
                        Id = treeTypeSql.PercentageSql?.Id ?? 0,
                        Value = treeTypeSql.PercentageSql?.Value ?? 0,
                    },
                    Tree = new Tree()
                    {
                        Id = treeTypeSql.TreeSql?.Id ?? 0,
                        Name = treeTypeSql.TreeSql?.Name ?? "",
                    }
                };
            return null;
        }

        public TreeTypeSql Convert(TreeType treeType)
        {
            if (treeType != null)
                return new TreeTypeSql()
                {
                    Id = treeType?.Id ?? 0,
                    PercentageSql = new PercentageSql()
                    {
                        Id = treeType.Percentage?.Id ?? 0,
                        Value = treeType.Percentage?.Value ?? 0,
                    },
                    TreeSql = new TreeSql()
                    {
                        Id = treeType.Tree?.Id ?? 0,
                        Name = treeType.Tree?.Name ?? "",
                    }
                };
            return null;
        }
    }
}