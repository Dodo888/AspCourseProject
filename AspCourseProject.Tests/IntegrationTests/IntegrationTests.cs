using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AspCourseProject.Domain.Entities;
using AspCourseProject.Domain.Interfaces;
using AspCourseProject.WebUI.Controllers;
using AspCourseProject.WebUI.Helpers;
using Moq;
using NUnit.Framework;

namespace AspCourseProject.Tests.IntegrationTests
{
    [TestFixture]
    public class IntegrationTests
    {
        private VoteController sutVoteController;
        private Mock<IRepository> sutDB;
        private Mock<IUserProvider> sutUserProvider;
        private List<Vote> votesList;
        private int week;
        private Mock<IWeekProvider> sutWeekProvider;

        [TestFixtureSetUp]
        public void Init()
        {
            votesList = new List<Vote>();
            week = 1;
            sutDB = new Mock<IRepository>();
            sutDB.Setup(m => m.Table).Returns(new Person[]
            {
                new Person {PersonId = 1, Name = "P1", Category = "1", Price=10},
                new Person {PersonId = 2, Name = "P2", Category = "2", Price=10},
                new Person {PersonId = 3, Name = "P3", Category = "1", Price=10},
                new Person {PersonId = 4, Name = "P4", Category = "2", Price=10},
                new Person {PersonId = 5, Name = "P5", Category = "1", Price=10}
            }.AsQueryable());

            sutDB.Setup(m => m.Votes).Returns(votesList.AsQueryable());
            sutDB.Setup(m => m.VoteItems).Returns(new VoteItem[] { }.AsQueryable());
            sutDB.Setup(m => m.SaveVote(It.IsAny<Vote>()))
                .Callback(() => votesList.Add(new Vote {VoteId = 0, Week = week, UserName = "Test"}))
                .Verifiable("not used");

            sutUserProvider = new Mock<IUserProvider>();
            sutUserProvider.Setup(m => m.GetUserName(It.IsAny<Controller>()))
                .Returns("Test");

            sutWeekProvider = new Mock<IWeekProvider>();
            sutWeekProvider.Setup(m => m.GetWeek())
                .Returns(week);

            sutVoteController = new VoteController(sutDB.Object, sutUserProvider.Object, sutWeekProvider.Object);
        }

        [Test]
        public void Can_Save_Votes_After_Checkout()
        {
            var votes = new VoteResults();
            sutVoteController.AddVote(votes, 1, "");
            sutVoteController.Checkout(votes);
            sutDB.Verify(m => m.SaveVote(It.IsAny<Vote>()));
        }

        [Test]
        public void Cannot_Vote_After_Checkout()
        {
            var votes = new VoteResults();
            sutWeekProvider.SetupSequence(m => m.GetWeek())
                .Returns(1).Returns(1);
            sutVoteController.AddVote(votes, 1, "");
            sutVoteController.Checkout(votes);
            sutVoteController.AddVote(votes, 2, "");
            sutVoteController.Checkout(votes);
            sutDB.Verify(m => m.SaveVote(It.IsAny<Vote>()), Times.Once);
        }

        [Test]
        public void Can_Vote_Next_Week()
        {   
            sutWeekProvider.SetupSequence(m => m.GetWeek())
                .Returns(1).Returns(2);
            var votes = new VoteResults();
            votesList = new List<Vote>();
            sutVoteController.AddVote(votes, 1, "");
            sutVoteController.Checkout(votes);
            sutVoteController.AddVote(votes, 2, "");
            sutVoteController.Checkout(votes);
            sutDB.Verify(m => m.SaveVote(It.IsAny<Vote>()), Times.Exactly(2));
        }
    }
}
