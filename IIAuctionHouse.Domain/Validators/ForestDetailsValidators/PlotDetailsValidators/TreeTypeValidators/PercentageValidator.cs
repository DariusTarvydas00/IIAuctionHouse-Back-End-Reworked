using System.IO;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;

namespace IIAuctionHouse.Domain.Validators.ForestDetailsValidators.PlotDetailsValidators.TreeTypeValidators
{
    public class PercentageValidator
    {
        public void DefaultValidation(Percentage percentage) {
            if (percentage == null)
            {
                throw new InvalidDataException("Percentage Cannot Be Null");
            }
            ValidateValue(percentage);
        }

        private void ValidateValue(Percentage percentage) {
            if (percentage.Value < 1)
            {
                throw new InvalidDataException("Percentage Value Cannot be less than 1");
            }
        }
        
        public void ValidateNumber(int number) {
            if (number < 1)
            {
                throw new InvalidDataException("Percentage or Id Cannot be less than 1");
            }
        }
    }
}