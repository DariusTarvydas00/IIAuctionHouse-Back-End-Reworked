using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;

namespace IIAuctionHouse.Domain.Validators.ForestDetailsValidators.PlotDetailsValidators.TreeTypeValidators
{
    public class TreeValidator
    {
        public void DefaultValidation(Tree tree) {
            if (tree == null)
            {
                throw new InvalidDataException("Tree Cannot Be Null");
            }
            ValidateValue(tree);
        }

        private void ValidateValue(Tree tree) {
            if (tree.Name.Any(char.IsDigit) || string.IsNullOrEmpty(tree.Name))
            {
                throw new InvalidDataException("Incorrect Tree Name");
            }
        }
        
        public void ValidateNumber(int number) {
            if (number < 1)
            {
                throw new InvalidDataException("Id Cannot be less than 1");
            }
        }
        
        public void ValidateValue(string name) {
            if (name.Any(char.IsDigit) || string.IsNullOrEmpty(name))
            {
                throw new InvalidDataException("Incorrect Tree Name");
            }
        }
    }
}