using NUnit.Framework;
using SocialNetworkAnalyser.Business.Managers;
using SocialNetworkAnalyser.Business.Models;
using SocialNetworkAnalyser.Data.Entities;
using SocialNetworkAnalyser.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkAnalyser.Tests.Managers
{
    [TestFixture]
    public class StatisticsManagerTest : BaseTestManager
    {
        private StatisticsManager _manager;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _manager = new StatisticsManager();
            _manager.SetRepositoryFactory(RepositoryFactory);
        }

        [Test]
        public void FriendsCountInDataSet_GetActualFriendsCount_ReturnsExactValue()
        {
            var dataSetId = Guid.NewGuid();
            AddFriend(1, dataSetId);
            AddFriend(2, dataSetId);
            AddFriend(3, Guid.NewGuid());

            int result = _manager.FriendsCountInDataSet(dataSetId);

            Assert.That(result, Is.EqualTo(2));
        }
        [Test]
        public void FriendsCountInDataSet_NotFoundFriendsById_ReturnsZero()
        {
            var wrongId = Guid.NewGuid();

            int result = _manager.FriendsCountInDataSet(wrongId);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void AverageFriendsCountForEachPerson_CorrectlyCalculatedAverageFriendsCount_ReturnsExactValue()
        {
            var dataSetId = Guid.NewGuid();
            AddFriendship(dataSetId, new List<Friend>() { new Friend(), new Friend() });
            AddFriendship(dataSetId, new List<Friend>() { new Friend() });
            AddFriendship(dataSetId, new List<Friend>() { new Friend(), new Friend() });

            var result = _manager.AverageFriendsCountForEachPerson(dataSetId);

            Assert.That(result, Is.EqualTo(1.67));
        }
        [Test]
        public void AverageFriendsCountForEachPerson_NotFoundFriendshipsById_ReturnsZero()
        {
            var dataSetId = Guid.NewGuid();
            AddFriendship(dataSetId, new List<Friend>());

            var result = _manager.AverageFriendsCountForEachPerson(dataSetId);

            Assert.That(result, Is.EqualTo(0));
        }


        private Friend AddFriend(int socialNetworkId, Guid dataSetId)
        {
            var friend = Friend.Create(socialNetworkId, dataSetId);
            FriendsRepository.Friends.Add(friend);

            return friend;
        }
        private Friendship AddFriendship(Guid dataSetId, List<Friend> friends)
        {
            var friendship = Friendship.Create(Guid.NewGuid(), dataSetId, friends);
            FriendshipRepository.Friendships.Add(friendship);

            return friendship;
        }
    }
}
