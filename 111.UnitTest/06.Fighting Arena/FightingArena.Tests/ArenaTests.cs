namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private Warrior warrior2;
        private string name;
        private string name2;
        private string name3;
        private int damage;
        private int hp;
        private int hp2;
        private const int MIN_ATTACK_HP = 30;

        [SetUp]
        public void SetUp()
        {
            name = "Alegro";
            name2 = "Bizon";
            name3 = "Z";
            damage = 10;
            hp = 50;
            hp2 = 100;

            arena = new Arena();
            warrior = new Warrior(name, damage, hp);
            warrior2 = new Warrior(name2, damage, hp2);

        }

        [Test]
        public void Test_Arena_Constructor_and_adding_Warriors()
        {
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            Assert.That(2, Is.EqualTo(arena.Count));
            Assert.IsTrue(arena.Warriors.Any(x => x.Name == name));
            Assert.IsTrue(arena.Warriors.Any(x => x.Name == name2));

            Assert.That(Assert.Throws<InvalidOperationException>(
                        () =>
                        {
                            arena.Enroll(warrior);

                        }, "Warrior is already enrolled for the fights!").Message,
                        Is.EqualTo("Warrior is already enrolled for the fights!"), "Wrong Massage!");            
        }
        [Test]
        public void Testing_In_Fight_Method_is_all_fighters_are_not_null()
        {
            arena.Enroll(warrior);
            arena.Enroll(warrior2);           

            Assert.That(Assert.Throws<InvalidOperationException>(
                        () =>
                        {
                            arena.Fight(warrior.Name, name3);

                        }, $"There is no fighter with name {name3} enrolled for the fights!").Message,
                        Is.EqualTo($"There is no fighter with name {name3} enrolled for the fights!"), "Wrong Massage!");


            Assert.That(Assert.Throws<InvalidOperationException>(
                        () =>
                        {
                            arena.Fight(name3, warrior.Name);

                        }, $"There is no fighter with name {name3} enrolled for the fights!").Message,
                        Is.EqualTo($"There is no fighter with name {name3} enrolled for the fights!"), "Wrong Massage!");

        }
    }
}
