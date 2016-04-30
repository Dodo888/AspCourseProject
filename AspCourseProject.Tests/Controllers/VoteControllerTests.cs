﻿using System.Linq;
using AspCourseProject.Domain;
using AspCourseProject.Domain.Entities;
using AspCourseProject.WebUI.Controllers;
using AspCourseProject.WebUI.Models;
using Moq;
using NUnit.Framework;

namespace AspCourseProject.Tests.Controllers
{
    [TestFixture]
    public class VoteControllerTests
    {
        private Mock<IPersonRepository> sutMock;
        private VoteController sutController;
        private VoteResults votes;

        [TestFixtureSetUp]
        public void Init()
        {
            sutMock = new Mock<IPersonRepository>();

            sutMock.Setup(m => m.Table).Returns(new Person[]
            {
                new Person {PersonId = 1, Name = "P1", Category = "1", Price=10},
                new Person {PersonId = 2, Name = "P2", Category = "2", Price=10},
                new Person {PersonId = 3, Name = "P3", Category = "1", Price=10},
                new Person {PersonId = 4, Name = "P4", Category = "2", Price=10},
                new Person {PersonId = 5, Name = "P5", Category = "1", Price=10}
            }.AsQueryable());
            sutController = new VoteController(sutMock.Object);
        }

        [Test]
        public void Can_Add_Person_To_Vote_List()
        {
            votes = new VoteResults();
            sutController.AddVote(votes, 1, "");
            // Assert
            Assert.AreEqual(votes.Votes.Count(), 1);
            Assert.AreEqual(votes.Votes.ToArray()[0].PersonId, 1);
        }

        [Test]
        public void Cannot_Add_Vote_Twice()
        {
            votes = new VoteResults();
            sutController.AddVote(votes, 1, "");
            sutController.AddVote(votes, 1, "");
            // Assert
            Assert.AreEqual(votes.Votes.Count(), 1);
            Assert.AreEqual(votes.Votes.ToArray()[0].PersonId, 1);
        }

        [Test]
        public void Can_Remove_Person_From_Vote_List()
        {
            votes = new VoteResults();
            sutController.AddVote(votes, 1, "");
            sutController.RemoveVote(votes, 1, "");
            // Assert
            Assert.AreEqual(votes.Votes.Count(), 0);
        }

        [Test]
        public void Cannot_Remove_Vote_Twice()
        {
            votes = new VoteResults();
            sutController.AddVote(votes, 1, "");
            sutController.RemoveVote(votes, 1, "");
            sutController.RemoveVote(votes, 1, "");
            // Assert
            Assert.AreEqual(votes.Votes.Count(), 0);
        }

        [Test]
        public void Cannot_Add_Votes_More_Expensive_Than_Balance()
        {
            votes = new VoteResults();
            sutController.AddVote(votes, 1, "");
            sutController.AddVote(votes, 2, "");
            sutController.AddVote(votes, 3, "");
            // Assert
            Assert.AreEqual(votes.Votes.Count(), 2);
        }

        [Test]
        public void Can_View_Cart_Contents()
        {
            votes = new VoteResults();
            VoteController target = new VoteController(null);
            VotesViewModel result = (VotesViewModel)target.Index(votes, "myUrl").ViewData.Model;
            // Assert
            Assert.AreSame(result.Votes, votes);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
        }
    }
}
