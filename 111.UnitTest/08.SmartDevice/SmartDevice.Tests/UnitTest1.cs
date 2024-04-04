namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;
    using static System.Collections.Specialized.BitVector32;
    using System.Xml.Linq;

    public class Tests
    {
        private Device device;
        private const int memoryCapacity = 50;
        
        
        [SetUp]
        public void Setup()
        {
            device = new Device(memoryCapacity);
        }

        [Test]
        public void Test_Consyructor()
        {
            Assert.NotNull(device);
            Assert.That(device.MemoryCapacity, Is.EqualTo(memoryCapacity));
            Assert.That(device.AvailableMemory, Is.EqualTo(memoryCapacity));
            Assert.That(device.Photos, Is.EqualTo(0));
            Assert.IsTrue(device.Applications.Count == 0);
        }
        [Test]
        [TestCase(100)]
        [TestCase(30)]
        public void Test_TakePhoto(int photoSize)
        {
            if (photoSize > 50 )
            {
                Assert.IsFalse(device.TakePhoto(photoSize));
            }
            else
            {
                Assert.IsTrue(device.TakePhoto(photoSize));
                Assert.That(device.Photos, Is.EqualTo(1));
                
            }
        }

        [Test]
        [TestCase("ALL", 60)]
        [TestCase("All", 30)]
        public void TEST_Isnstall_App(string AppName, int AppSize)
        {
            if (AppSize > 50)
            {
                Assert.That(Assert.Throws<InvalidOperationException>(
                       () =>
                       {
                            device.InstallApp(AppName, AppSize);

                       }, "Not enough available memory to install the app.").Message,
                       Is.EqualTo("Not enough available memory to install the app."), "Wrong Massage!");
            }
            else
            {
                Assert.That(device.InstallApp(AppName, AppSize), Is.EqualTo($"{AppName} is installed successfully. Run application?"));
                Assert.That(device.AvailableMemory, Is.EqualTo(20));
                Assert.That(device.Applications.Count, Is.EqualTo(1));
                Assert.That(device.Applications[0], Is.EqualTo(AppName));


                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendLine($"Memory Capacity: 50 MB, Available Memory: 20 MB");
                stringBuilder.AppendLine($"Photos Count: 0");
                stringBuilder.AppendLine($"Applications Installed: {AppName}");
                Assert.That(stringBuilder.ToString().Trim(), Is.EqualTo( device.GetDeviceStatus()));


                device.FormatDevice();

                Assert.That(device.Applications.Count, Is.EqualTo(0));
                Assert.That(device.Photos, Is.EqualTo(0));
                Assert.That(device.AvailableMemory, Is.EqualTo(50));
                
            }
        }

        [Test]
        public void GEt_status()
        {
            
        }
    }
}