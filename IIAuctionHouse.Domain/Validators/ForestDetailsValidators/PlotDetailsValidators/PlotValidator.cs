using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels;

namespace IIAuctionHouse.Domain.Validators.ForestDetailsValidators.PlotDetailsValidators
{
    public class PlotValidator
    {
        public void DefaultValidation(Plot plot) {
            if (plot == null)
            {
                throw new InvalidDataException("Plot Cannot Be Null");
            }
            ValidateValue(plot);
        }

        private void ValidateValue(Plot plot) {
            ValidateId(plot.Id);
            ValidateValue(plot.Volume, plot.PlotSize, plot.PlotTenderness, plot.AverageTreeHeight,plot.PlotResolution);
        }
        
        public void ValidateId(int number) {
            if (number < 1)
            {
                throw new InvalidDataException("Id Cannot be less than 1");
            }
        }

        public void ValidateValue(int volume, double plostSize, double plotTenderness, int averageTreeHeight, string plotResolution) {
            if (plotResolution.Any(char.IsDigit) || string.IsNullOrEmpty(plotResolution))
            {
                throw new InvalidDataException("Incorrect Plot Resolution");
            }
            if (volume < 1 || plostSize < 0.1 || plotTenderness < 0.1 || averageTreeHeight < 1)
            {
                throw new InvalidDataException("Some of The Values Are Incorrect");
            }
        }
    }
}