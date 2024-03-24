using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(2, 4);
            dummy = new Dummy(100, 100);
        }


        [Test]
        [TestCase(1, 3)]
        [TestCase(3, 1)]
        public void Test_Axe_Durability_Reduction(int hits, int expectedPoints)
        {           

            for (int i = 0; i < hits; i++)
            {
                axe.Attack(dummy);
            }

            Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedPoints), "Axe Durability doesn't change after attack.");            
        }

        [Test]

        public void When_Hit_Axe_Should_be_broken()
        {
            Assert.That(
                Assert.Throws<InvalidOperationException>
                (
                    () =>
                    {
                        for (int i = 1; i < 6; i++)
                        {
                            axe.Attack(dummy);
                        }

                    }
                    ,"Expectation for broken weapon was not conformed")
                .Message,
            Is.EqualTo("Axe is broken."));

        }
    }
}