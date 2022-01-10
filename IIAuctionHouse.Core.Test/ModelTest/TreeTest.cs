using IIAuctionHouse.Core.Models;
using Xunit;

namespace IIAuctionHouse.Core.Test.ModelTest
{
    public class TreeTest
    {
        private readonly Tree _tree;

        public TreeTest()
        {
            _tree = new Tree()
            {
                Id = 1,
                Name = "Birch",
            };
        }

        // Checks if Test class can be initialized
        [Fact]
        public void Test_CanBeInitialized()
        {
            Assert.NotNull(_tree);
        }
        
        # region Id Property Test
        
        [Fact]
        // Check if Id property exists
        public void Id_Exists()
        {
            Assert.True(_tree.GetType().GetProperty("Id") != null);
        }
        // Check if Id is integer value type
        [Fact]
        public void Id_isIntegerType()
        {
            Assert.True(_tree.Id is int);
        }
        
        // Checking if Id value is stored
        [Fact]
        public void Id_SetId_StoresId()
        {
            Assert.Equal(1,_tree.Id);
        }
        
        // Checking if Id value is updated
        [Fact]
        public void Id_UpdateId_StoresNewIdValues()
        {
            _tree.Id = 2;
            Assert.Equal(2,_tree.Id);
        }
        
        #endregion
        
        # region TestAmount Property Test
        
        [Fact]
        // Check if Test name property exists
        public void Name_Exists()
        {
            Assert.True(_tree.GetType().GetProperty("Name") != null);
        }
        
        // Checking if Name value is stored
        [Fact]
        public void Name_SetName_StoresName()
        {
            Assert.Equal("Birch",_tree.Name);
        }
        
        // Checking if Name value is updated
        [Fact]
        public void Name_UpdateName_StoresNewNameValues()
        {
            _tree.Name = "Aspen";
            Assert.Equal("Aspen",_tree.Name);
        }
        
        #endregion
        
    }
    
}