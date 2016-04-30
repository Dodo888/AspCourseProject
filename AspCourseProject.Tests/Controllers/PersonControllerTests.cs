using System.Linq;
using AspCourseProject.Domain;
using AspCourseProject.Domain.Entities;
using AspCourseProject.WebUI.Controllers;
using AspCourseProject.WebUI.Models;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace AspCourseProject.Tests.Controllers
{
    [TestFixture]
    public class PersonControllerTest
    {
        private Mock<IPersonRepository> sutMock;
        private PersonController sutController;

        [TestFixtureSetUp]
        public void Init()
        {
            sutMock = new Mock<IPersonRepository>();

            sutMock.Setup(m => m.Table).Returns(new Person[]
            {
                new Person {PersonId = 1, Name = "P1", Category = "1", IsAlive = true},
                new Person {PersonId = 2, Name = "P2", Category = "2", IsAlive = true},
                new Person {PersonId = 3, Name = "P3", Category = "1", IsAlive = true},
                new Person {PersonId = 4, Name = "P4", Category = "2", IsAlive = true},
                new Person {PersonId = 5, Name = "P5", Category = "1", IsAlive = true}
            }.AsQueryable());
            sutController = new PersonController(sutMock.Object);
            sutController.pageSize = 3;
        }

        [Test]
        public void Can_Send_Pagination_View_Model()
        {
            var result = (PersonsListViewModel)sutController.List("all","all", null,2).Model;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [Test]
        public void Can_Paginate()
        {
            var result = ((PersonsListViewModel)sutController.List("all", "all", null, 2).Model).Persons.ToArray();
            Assert.IsTrue(result.Length == 2);
            Assert.AreEqual(result[0].Name, "P4");
            Assert.AreEqual(result[1].Name, "P5");
        }

        [Test]
        public void Can_Filter_Products()
        {
            var result = ((PersonsListViewModel)sutController.List("2","all", null, 1).Model).Persons.ToArray();
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "2");
        }
    }
}
