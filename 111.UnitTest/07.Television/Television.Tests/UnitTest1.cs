namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using System.Xml.Linq;
    using NUnit.Framework;
    using static System.Collections.Specialized.BitVector32;

    public class Tests
    {
        private TelevisionDevice TV;
        private string brand;
        private double price;
        private int screenWidth;
        private int screenHeight;
       

        [SetUp]
        public void Setup()
        {
            brand = "Sony";
            price = 100;
            screenWidth = 10;
            screenHeight = 10;
            TV = new TelevisionDevice(brand, price, screenWidth, screenHeight);
        }

        [Test]
        public void Test_TV_constructor()
        {
            TV = new TelevisionDevice(brand, price, screenWidth, screenHeight);

            Assert.NotNull(TV);
            Assert.AreEqual("Sony", TV.Brand);
            Assert.AreEqual(100, TV.Price);
            Assert.That(10, Is.EqualTo(TV.ScreenWidth));
            Assert.That(10, Is.EqualTo(TV.ScreenHeigth));
        }
        [Test]
        public void TEst_SwithcON()
        {
            TV.SwitchOn();

            Assert.IsTrue($"Cahnnel 0 - Volume 13 - Sound On" == TV.SwitchOn());   
        }

        [Test]
        public void ChanngChanenel()
        {           

            Assert.That(Assert.Throws<ArgumentException>(
            () =>
            {
                TV.ChangeChannel(-2);

            }, "Invalid key!").Message,
            Is.EqualTo("Invalid key!"), "Wrong Massage!");


            Assert.IsTrue(5 == TV.ChangeChannel(5));
            
        }

        [Test]
        public void TestVolume()
        {
           

            Assert.AreEqual("Volume: 100", TV.VolumeChange("UP", 100));
            Assert.AreEqual("Volume: 0", TV.VolumeChange("DOWN", 150));
            Assert.AreEqual("Volume: 50", TV.VolumeChange("UP", 50));
            Assert.AreEqual("Volume: 60", TV.VolumeChange("UP", -10));
            Assert.AreEqual("Volume: 40", TV.VolumeChange("DOWN", 20));
        }
        [Test]

        public void MuteDeviceTest()
        {
            Assert.IsTrue(true == TV.MuteDevice());
            Assert.IsTrue(false == TV.MuteDevice());
        }

        [Test]

        public void Print()
        {
            Assert.AreEqual($"TV Device: Sony, Screen Resolution: 10x10, Price 100$", TV.ToString());
        }
    }
}