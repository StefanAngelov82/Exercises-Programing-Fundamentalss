namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Runtime.ExceptionServices;

    [TestFixture]
    public class WarriorTests
    {
       
        private Warrior warrior;
        private Warrior warrior2;
        private string name;
        private string name2;
        private int damage;
        private int hp;
        private int hp2;
        private const int MIN_ATTACK_HP = 30;


        [SetUp]
        public void SetUp()
        {
            name = "Alegro";
            name2 = "Bizon";
            damage = 10;
            hp = 50;
            hp2 = 100;
                     

        }

        [Test]
        public void Test_of_Warrior_constructor()
        {
            warrior = new Warrior(name, damage, hp);

            Assert.That(name, Is.EqualTo(warrior.Name));
            Assert.That(damage, Is.EqualTo(warrior.Damage));
            Assert.That(hp, Is.EqualTo(warrior.HP));
        }

        [Test]

        public void Test_Warrior_Params_Constrains()
        {     
            
            // test for name

            Assert.That
             (
                  Assert.Throws<ArgumentException>
                     (
                         () =>
                         {
                             warrior = new Warrior("", damage, hp);
                         },
                     "Name should not be empty or whitespace!, exception is expected"

                     ).Message,
                  Is.EqualTo("Name should not be empty or whitespace!"),
                     "Wrong Massage!"
             );

            // test for damage

            Assert.That
             (
                  Assert.Throws<ArgumentException>
                     (
                         () =>
                         {
                             warrior = new Warrior(name, 0, hp);
                         },
                     "Damage value should be positive!, exception is expected"

                     ).Message,
                  Is.EqualTo("Damage value should be positive!"),
                     "Wrong Massage!"
             );

            // test for HP

            Assert.That
             (
                  Assert.Throws<ArgumentException>
                     (
                         () =>
                         {
                             warrior = new Warrior(name, damage, - 5);
                         },
                     "HP should not be negative!, exception is expected"

                     ).Message,
                  Is.EqualTo("HP should not be negative!"),
                     "Wrong Massage!"
             );
        }

        [Test]
        [TestCase(20)]
        [TestCase(50)]
        [TestCase(60)]
        public void Test_attack_of_warrior(int attackPower)
        {
            warrior = new Warrior(name, damage, hp);
            warrior2 = new Warrior(name2,attackPower, hp2);

            warrior2.Attack(warrior);

            if (attackPower <= hp)
            {
                Assert.True(hp2 - damage == warrior2.HP);
                Assert.True(hp - attackPower == warrior.HP);
            }
            else
            {
                Assert.True(hp2 - damage == warrior2.HP);
                Assert.True(0 == warrior.HP);
            }
        }

        [Test]
        
        public void Test_of_warrior_Attack_method_constrains()
        {
            warrior = new Warrior(name, damage, 20);
            warrior2 = new Warrior(name, damage, 20);           

            Assert.That
             (
                  Assert.Throws<InvalidOperationException>
                     (
                         () =>
                         {
                             warrior.Attack(warrior2);
                         },
                     "Your HP is too low in order to attack other warriors!, exception is expected"

                     ).Message,
                  Is.EqualTo("Your HP is too low in order to attack other warriors!"),
                     "Wrong Massage!"
             );

            warrior2 = new Warrior(name, damage, 60);

            Assert.That
             (
                  Assert.Throws<InvalidOperationException>
                     (
                         () =>
                         {
                             warrior2.Attack(warrior);
                         },
                     $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!, exception is expected"

                     ).Message,
                  Is.EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"),
                     "Wrong Massage!"
             );

            warrior = new Warrior(name, damage, 40);
            warrior2 = new Warrior(name, 100, 80);

            Assert.That(Assert.Throws<InvalidOperationException>(
                        () =>
                        {
                            warrior.Attack(warrior2);

                        },"You are trying to attack too strong enemy").Message,
                        Is.EqualTo("You are trying to attack too strong enemy"),"Wrong Massage!");
        }

        
    }
}