using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private int health = 10;
        private int experience = 10;
        private int attackPoints = 10;


        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(health, experience);
        }

        [Test]
        [TestCase(2, 8)]
        [TestCase(0, 10)]
        public void When_is_Attacked_Dummy_loose_health(int attackPoints, int expectedHealth)
        {
            dummy.TakeAttack(attackPoints);

            Assert.That(dummy.Health, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void When_Attack_DeadDummy_Exception_should_be_Thrown()
        {
            Assert.That(
                Assert.Throws<InvalidOperationException>
                (
                    () =>
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            dummy.TakeAttack(attackPoints);
                        }

                    }, "Dummy should be dead"

                ).Message,
            Is.EqualTo("Dummy is dead."), "Incorrect message");
        }

        [Test]
        public void When_Dummy_is_Killed_Should_Give_Exp()
        {
            dummy.TakeAttack(attackPoints);

            Assert.AreEqual(experience, dummy.GiveExperience());
        }

        [Test]
        public void When_Dummy_is_not_Dead_should_not_Return_Exp()
        {
            
            Assert.That(
                Assert.Throws<InvalidOperationException>
                (
                    () =>
                    {
                        dummy.GiveExperience();

                    }, "Dummy is not dead"

                ).Message,
            Is.EqualTo("Target is not dead."), "Incorrect message");
        }
    }
}