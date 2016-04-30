using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspCourseProject.Domain;
using AspCourseProject.Domain.Entities;
using AspCourseProject.WebUI.Controllers;
using AspCourseProject.WebUI.Models;
using Moq;
using NUnit.Framework;

namespace AspCourseProject.Tests.Controllers
{
    [TestFixture]
    internal class NavigationControllerTests
    {
        private Mock<IPersonRepository> sutMock;
        private NavigationController sutController;

        [TestFixtureSetUp]
        public void Init()
        {
            sutMock = new Mock<IPersonRepository>();
            sutMock.Setup(m => m.Table).Returns(new Person[]
            {
                new Person {PersonId = 1, Name = "P1", Category = "House of Stark"},
                new Person {PersonId = 2, Name = "P2", Category = "House of Stark"},
                new Person {PersonId = 3, Name = "P3", Category =  "House of Baratheon"},
                new Person {PersonId = 4, Name = "P4", Category = "House of Baratheon"},
            }.AsQueryable());
            sutController = new NavigationController(sutMock.Object);
        }

        [Test]
        public void Can_Create_Categories()
        {
            var results = ((MenuCategoryViewModel)sutController.MenuCategory().Model).Categories.ToArray();
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[1], "House of Stark");
            Assert.AreEqual(results[0], "House of Baratheon");

        }

        [Test]
        public void Indicates_Selected_Category()
        {
            var categoryToSelect = "House of Baratheon";
            var result = ((MenuCategoryViewModel)sutController.MenuCategory(category: categoryToSelect).Model).Categories.ToArray().First();
            Assert.AreEqual(categoryToSelect, result);
        }
    }
}
