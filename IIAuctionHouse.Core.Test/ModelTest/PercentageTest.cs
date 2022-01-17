using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using Xunit;

namespace IIAuctionHouse.Core.Test.ModelTest
{
    public class PercentageTest
    {
        private readonly Percentage _percentage;

        public PercentageTest()
        {
            _percentage = new Percentage()
            {
                Id = 1,
                Value = 7601,
            };
        }

        // Checks if Value class can be initialized
        [Fact]
        public void Value_CanBeInitialized()
        {
            Assert.NotNull(_percentage);
        }

        # region Id Property Test

        [Fact]
        // Check if Id property exists
        public void Id_Exists()
        {
            Assert.True(_percentage.GetType().GetProperty("Id") != null);
        }

        // Check if Id is integer value type
        [Fact]
        public void Id_isIntegerType()
        {
            Assert.True(_percentage.Id is int);
        }

        // Checking if Id value is stored
        [Fact]
        public void Id_SetId_StoresId()
        {
            Assert.Equal(1, _percentage.Id);
        }

        // Checking if Id value is updated
        [Fact]
        public void Id_UpdateId_StoresNewIdValues()
        {
            _percentage.Id = 2;
            Assert.Equal(2, _percentage.Id);
        }

        #endregion

        # region Value Property Test

        [Fact]
        // Check if Value property exists
        public void Value_Exists()
        {
            Assert.True(_percentage.GetType().GetProperty("Value") != null);
        }

        // Check if Value is integer value type
        [Fact]
        public void Value_isIntegerType()
        {
            Assert.True(_percentage.Value is int);
        }

        // Checking if Value is stored
        [Fact]
        public void Value_SetValue_StoresValue()
        {
            Assert.Equal(7601, _percentage.Value);
        }

        // Checking if Value is updated
        [Fact]
        public void Value_UpdateValue_StoresNewValues()
        {
            _percentage.Value = 7000;
            Assert.Equal(7000, _percentage.Value);
        }

        #endregion
    }
}