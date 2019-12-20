using HappyRentals.Domain.Abstract;
using HappyRentals.Domain.Entities;
using HappyRentals.WebUI.Controllers;
using HappyRentals.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace HappyRentals.Tests
{
    [TestClass]
    public class NavigationTests
    {
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            //Arrange
            Mock<IHomeOwnerRepository> mock = new Mock<IHomeOwnerRepository>();
            mock.Setup(m => m.HomeOwners).Returns(new HomeOwner[]{
                new HomeOwner{ HomeOwnerId = 1, Name = "HO1"},
                new HomeOwner{ HomeOwnerId = 2, Name="HO2"},
                new HomeOwner{ HomeOwnerId = 3, Name="HO3"},
                new HomeOwner{ HomeOwnerId = 4, Name="HO4"},
                new HomeOwner{ HomeOwnerId = 5, Name="HO5"}
            }.AsQueryable());

            //Arrange
            HomeOwnerController controller = new HomeOwnerController(mock.Object);
            controller.PageSize = 3;

            //Act
            HomeOwnerListViewModel result = (HomeOwnerListViewModel)controller.List(2).Model;

            //Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
