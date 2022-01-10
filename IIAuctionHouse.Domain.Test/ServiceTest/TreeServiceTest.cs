using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.Services;
using Moq;
using Xunit;

namespace IIAuctionHouse.Domain.Test.ServiceTest
{
    public class TreeServiceTest
    {
        private readonly TreeService _service;
        private readonly Mock<ITreeRepository> _mock;
        private readonly List<Tree> _expected;

        public TreeServiceTest()
        {
            _mock = new Mock<ITreeRepository>();
            _service = new TreeService(_mock.Object);
            _expected = new List<Tree>()
            {
                new Tree()
                {
                    Id = 1,
                    Name = "Birch",
                },
                new Tree()
                {
                    Id = 2,
                    Name = "Aspen",
                }
            };
        }

        // Checking if Service is Using Interface
        [Fact]
        public void TreeService_IsITreeService()
        {
            Assert.True(_service is ITreeService);
        }

        // Checking throw exception if ITreeService is null
        [Fact]
        public void TreeService_WithNullRepositoryException_ThrowsInvalidDataException()
        {
            Assert.Throws<NullReferenceException>(() => new TreeService(null));
        }

        [Fact]
        public void TreeService_WithNullRepositoryException_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Tree Repository Cannot be null";
            var actual = Assert.Throws<NullReferenceException>(() => new TreeService(null));
            Assert.Equal(expected, actual.Message);
        }

        // Checks if ReadAll method calls TreeRepository only one time
        [Fact]
        public void ReadAll_CallsTreeRepositoryReadAll_ExactlyOnce()
        {
            _service.GetAll();
            _mock.Verify(r => r.FindAll(), Times.Once);
        }

        // Checks if ReadAll method returns list of Trees
        [Fact]
        public void ReadAll_NoFilter_ReturnsListOfTrees()
        {
            _mock.Setup(r => r.FindAll()).Returns(_expected);
            var actual = _service.GetAll();
            Assert.Equal(_expected, actual);
        }

        // Checks if Creating Tree Object is possible
        [Fact]
        public void Create_WithNull_ThrowsExceptionWithMessage()
        {
            var newTree = new Tree()
            {
                Id = 1,
                Name = "Aspen"
            };
            _mock.Setup(r=>r.Create(newTree)).Returns(newTree);
            var actual = _service.Create(newTree);
            Assert.Equal(newTree, actual);
        }

        // Checks if Updating Object is possible
        [Theory]
        [ClassData(typeof(TestCreateDataClass))]
        public void Update_WithNull_ThrowsExceptionWithMessage(int id, string name, string expected)
        {
            var actual = Assert.Throws<InvalidDataException>(() => 
                _service.UpdateTree(id,name));
            Assert.Equal(expected, actual.Message);
        }

        // Check if Delete Method throws exception
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsException(int value)
        {
            Assert.Throws<InvalidDataException>(() => _service.Delete(value));
        }

        // Checks if Delete with null throws exception message
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsExceptionMessage(int value)
        {
            const string expected = "Incorrect Tree Id";
            var actual = Assert.Throws<InvalidDataException>(() => _service.Delete(value));
            Assert.Equal(expected, actual.Message);
        }

        [Fact]
        public void Delete_Int_DeletesCustomerDetails()
        {
            Assert.Null(_service.Delete(1));
        }

        private class TestCreateDataClass : IEnumerable<object[]>
        {
            static string expected = "Incorrect Tree Name or Id";

            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] {-1, "Aspen", expected},
                new object[] {1, null, expected},
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}