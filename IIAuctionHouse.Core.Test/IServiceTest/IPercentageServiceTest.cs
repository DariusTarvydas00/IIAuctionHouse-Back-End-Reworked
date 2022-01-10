using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;

namespace IIAuctionHouse.Core.Test.IServiceTest
{
    public class IPercentageServiceTest
    {
          // Checking if IPercentageService is available
        [Fact]
        public void IPercentageService_IsAvailable()
        {
            var service = new Mock<IPercentageService>();
            Assert.NotNull(service);
        }
        
        // Checking if ReadAll method return a list
        [Fact]
        public void ReadAll_ReturnsListOfAllPercentages()
        {
            var mock = new Mock<IPercentageService>();
            var fakeList = new List<Percentage>();
            mock.Setup(s => s.GetAll()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList,service.GetAll());
        }
       
        
        // Checking if Percentage object is created
        [Fact]
        public void Create_Percentage_IsCreated()
        {
            var mock = new Mock<IPercentageService>();
            var fakePercentage = new Percentage()
            {
                Id = 1,
                Value = 7000,
            };
            mock.Setup(s => s.NewPercentage( It.IsAny<int>()))
                .Returns(() => fakePercentage);
            var service = mock.Object;
            Assert.Equal(fakePercentage,service.NewPercentage(7000));
        }
        
        // Checking if Percentage object is updated
        [Fact]
        public void Update_Percentage_IsUpdated()
        {
            var mock = new Mock<IPercentageService>();
            var fakePercentage = new Percentage()
            {
                Id = 1,
                Value = 8000,
            };
            mock.Setup(s => s.UpdatePercentage(fakePercentage.Id,fakePercentage.Value)).Returns(fakePercentage);
            var service = mock.Object;
            Assert.Equal(fakePercentage,service.UpdatePercentage(fakePercentage.Id,fakePercentage.Value));
            mock.Setup(s => s.Update(fakePercentage)).Returns(fakePercentage);
            var service2 = mock.Object;
            Assert.Equal(fakePercentage,service2.Update(fakePercentage));
        }
        
        // Checks if Delete method deletes object
        [Fact]
        public void Delete_Id_ReturnNull()
        {
            var mock = new Mock<IPercentageService>();
            var fakeList = new List<Percentage>();
            var bid = new Percentage()
            { 
                Id = 1,
                Value = 8000,
            };
            fakeList.Add(bid);
            mock.Setup(s => s.Delete(1)).Returns(() => null);
            var service = mock.Object;
            Assert.Null(service.Delete(1));
        }
    }
}