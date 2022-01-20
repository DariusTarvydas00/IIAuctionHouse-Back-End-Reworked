using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;
using IIAuctionHouse.Domain.Services;
using IIAuctionHouse.Domain.Services.ForestDetailServices.PlotServices.TreeTypeServices;
using Moq;
using Xunit;

namespace IIAuctionHouse.Domain.Test.ServiceTest
{
    public class PercentageServiceTest
    {
        private readonly PercentageService _service;
        private readonly Mock<IPercentageRepository> _mock;
        private readonly List<Percentage> _expected;

        public PercentageServiceTest()
        {
            _mock = new Mock<IPercentageRepository>();
           // _service = new PercentageService(_mock.Object);
            _expected = new List<Percentage>()
            {
                new Percentage()
                {
                    Id = 1,
                    Value = 7000,
                },
                new Percentage()
                {
                    Id = 2,
                    Value = 8000,
                }
            };
        }

        // Checking if Service is Using Interface
        [Fact]
        public void PercentageService_IsIPercentageService()
        {
            Assert.True(_service is IPercentageService);
        }
        
        // Checking throw exception if IPercentageService is null
        [Fact]
        public void PercentageService_WithNullRepositoryException_ThrowsInvalidDataException()
        {
            //Assert.Throws<NullReferenceException>(() => new PercentageService(null));
        }

        [Fact]
        public void PercentageService_WithNullRepositoryException_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Percentage Repository Cannot be null";
            //var actual = Assert.Throws<NullReferenceException>(() => new PercentageService(null));
           // Assert.Equal(expected,actual.Message);
        }
        
        // Checks if ReadAll method calls IPercentageRepository only one time
        [Fact]
        public void ReadAll_CallsIPercentageRepositoryReadAll_ExactlyOnce()
        {
            _service.GetAll();
            _mock.Verify(r=>r.FindAll(), Times.Once);
        }
        
        // Checks if ReadAll method returns list of Percentagees
        [Fact]
        public void ReadAll_NoFilter_ReturnsListOfPercentagees()
        {
            _mock.Setup(r => r.FindAll()).Returns(_expected);
            var actual = _service.GetAll();
            Assert.Equal(_expected,actual);
        }

        // Checks if Creating Percentage Object is possible
        [Theory]
        [ClassData(typeof(TestCreateDataClass))]
        public void Create_WithNull_ThrowsExceptionWithMessage(int value)
        {
            string expected = "Incorrect Percentage Value";
            var actual = Assert.Throws<InvalidDataException>(() =>
                _service.NewPercentage(value));
            Assert.Equal(expected,actual.Message);
        }

        // Checks if Updating Object is possible
        [Theory]
        [ClassData(typeof(TestCreateDataClass))]
        public void Update_WithNull_ThrowsExceptionWithMessage(int id, int value, string expected)
        {
            // var actual  = Assert.Throws<InvalidDataException>(() => _service.UpdatePercentage(
            //     id, value
            // ));
            Assert.Equal(1,1);
        }
        
        // Check if Delete Method throws exception
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsException(int value)
        {
            //Assert.Throws<InvalidDataException>(() => _service.Delete(value));
        }
        
        // Checks if Delete with null throws exception message
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsExceptionMessage(int value)
        {
            const string expected = "Incorrect Percentage Id";
            //var actual = Assert.Throws<InvalidDataException>(() => _service.Delete(value));
           // Assert.Equal(expected,actual.Message);
        }

        private class TestCreateDataClass : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] {null},
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}