using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspCourseProject.Domain.Entities;
using NUnit.Framework;

namespace AspCourseProject.Tests.ModelsTests
{
    [TestFixture]
    class VoteResultTests
    {
        private VoteResults sut;
        private Person p1;
        private Person p2;
        [TestFixtureSetUp]
        public void Init()
        {
            p1 = new Person { PersonId = 1, Name = "P1" };
            p2 = new Person { PersonId = 2, Name = "P2" };
            sut = new VoteResults();
        }

        [Test]
        public void Can_Add_New_Lines()
        {
            sut.AddVote(p1);
            sut.AddVote(p2);
            var results = sut.GetVotes.OrderBy(x => x.Name).ToArray();
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0], p1);
            Assert.AreEqual(results[1], p2);
        }
        [Test]
        public void Can_Delete_Some_Lines()
        {
            sut.AddVote(p1);
            sut.AddVote(p2);
            sut.RemoveVote(p1);
            var results = sut.GetVotes.OrderBy(x => x.Name).ToArray();
            Assert.AreEqual(results.Length, 1);
            Assert.AreEqual(results[0], p2);
        }
        [Test]
        public void Cant_Delete_two_times()
        {
            sut.AddVote(p1);
            sut.AddVote(p2);
            sut.RemoveVote(p1);
            sut.RemoveVote(p1);
            var results = sut.GetVotes.OrderBy(x => x.Name).ToArray();
            Assert.AreEqual(results.Length, 1);
            Assert.AreEqual(results[0], p2);
        }

        [Test]
        public void Cant_Delete_unexisted_plane()
        {
            sut.AddVote(p1);
            sut.AddVote(p2);
            var p3 = new Person() { PersonId = 3, Name = "P3" };
            var results = sut.GetVotes.OrderBy(x => x.Name).ToArray();
            sut.RemoveVote(p3);
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0], p1);
            Assert.AreEqual(results[1], p2);
        }
    }
}
