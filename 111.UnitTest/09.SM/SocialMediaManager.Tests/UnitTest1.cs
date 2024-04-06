using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

namespace SocialMediaManager.Tests
{
    public class Tests
    {

        private Influencer fluencer;
        private Influencer fluencer2;
        private string username;
        private int followers;
        private  InfluencerRepository repository;

        [SetUp]
        public void Setup()
        {
            username = "SS";
            followers = 1;
            fluencer = new Influencer(username, followers);
            fluencer2 = new Influencer("KK", 5);
            repository = new InfluencerRepository();
        }

        [Test]
        public void Test_INF()
        {
            Assert.NotNull(fluencer);
            Assert.That(fluencer.Username, Is.EqualTo("SS"));
            Assert.That(fluencer.Followers, Is.EqualTo(1));

        }

        [Test]
        public void Test_IFREP()
        {
            Assert.That(repository.Influencers.Count, Is.EqualTo(0));
        }

        [Test]

        public void RegisterInfluence_TEST()
        {
            

            Assert.That(Assert.Throws<ArgumentNullException>(
            () =>
            {
                repository.RegisterInfluencer(null);
                //repository.RemoveInfluencer(null);

                       }, "Influencer is null (Parameter 'influencer')").Message,
                       Is.EqualTo("Influencer is null (Parameter 'influencer')"), "Wrong Massage!");
        }

        [Test]
        public void RegisterInfluence_TEST2()
        {
            Assert.That(repository.RegisterInfluencer(fluencer), Is.EqualTo($"Successfully added influencer {fluencer.Username} with {fluencer.Followers}"));

            

            Assert.That(repository.Influencers.Count, Is.EqualTo(1));

            Assert.That(Assert.Throws<InvalidOperationException>(
            () =>
            {
                repository.RegisterInfluencer(fluencer);

            }, $"Influencer with username {fluencer.Username} already exists").Message,
                       Is.EqualTo($"Influencer with username {fluencer.Username} already exists"), "Wrong Massage!");

        }

        [Test]
        public void REM_Test()
        {
            repository.RegisterInfluencer(fluencer);

            Assert.That(Assert.Throws<ArgumentNullException>(
            () =>
            {
                repository.RemoveInfluencer("");

            }, $"Username cannot be null (Parameter 'username')").Message,
                       Is.EqualTo($"Username cannot be null (Parameter 'username')"));


            Assert.IsFalse(repository.RemoveInfluencer("NN"));
            Assert.IsTrue(repository.RemoveInfluencer("SS"));
        }

        [Test]
        public void MOST()
        {
            repository.RegisterInfluencer(fluencer);
            repository.RegisterInfluencer(fluencer2);

            Assert.AreEqual(repository.GetInfluencerWithMostFollowers(), fluencer2);
            Assert.AreEqual(repository.GetInfluencer("SS"), fluencer);

        }


    }
}