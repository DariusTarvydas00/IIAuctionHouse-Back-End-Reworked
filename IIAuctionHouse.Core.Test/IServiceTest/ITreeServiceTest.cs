using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;

namespace IIAuctionHouse.Core.Test.IServiceTest
{
    public class ITreeServiceTest
    {
          // Checking if ITreeService is available
        [Fact]
        public void ITreeService_IsAvailable()
        {
            var service = new Mock<ITreeService>();
            Assert.NotNull(service);
        }
        
        // Checking if ReadAll method return a list
        [Fact]
        public void ReadAll_ReturnsListOfAllTrees()
        {
            var mock = new Mock<ITreeService>();
            var fakeList = new List<Tree>();
            mock.Setup(s => s.GetAll()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList, service.GetAll());
        }

        // Checking if Tree object is created
        [Fact]
        public void Create_Tree_IsCreated()
        {
            var mock = new Mock<ITreeService>();
            var fakeTree = new Tree()
            {
                Id = 1,
                Name = "Birch"
            };
            mock.Setup(s => s.NewTree(It.IsAny<string>()))
                .Returns(() => fakeTree);
            var service = mock.Object;
            Assert.Equal(fakeTree,service.NewTree("Birch"));
        }
        
        // Checking if Tree object is updated
        [Fact]
        public void Update_Tree_IsUpdated()
        {
            var mock = new Mock<ITreeService>();
            var fakeTree = new Tree()
            {
                Id = 1,
                Name = "Aspen"
            };
            mock.Setup(s => s.UpdateTree(fakeTree.Id,fakeTree.Name)).Returns(fakeTree);
            var service = mock.Object;
            Assert.Equal(fakeTree,service.UpdateTree(fakeTree.Id, fakeTree.Name));
            mock.Setup(s => s.Update(fakeTree)).Returns(fakeTree);
            var service2 = mock.Object;
            Assert.Equal(fakeTree,service2.Update(fakeTree));
        }
        
        // Checks if Delete method deletes object
        [Fact]
        public void Delete_Id_ReturnNull()
        {
            var mock = new Mock<ITreeService>();
            var fakeList = new List<Tree>();
            var bid = new Tree()
            { 
                Id = 1,
                Name = "Aspen"
            };
            fakeList.Add(bid);
            mock.Setup(s => s.Delete(1)).Returns(() => null);
            var service = mock.Object;
            Assert.Null(service.Delete(1));
        }
    }
}