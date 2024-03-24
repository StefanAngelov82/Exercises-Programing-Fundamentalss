namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Diagnostics.Metrics;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private int[] actual;
        private int[] input2;

        [SetUp]
        public void SetUp()
        {
            input2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            database = new Database(input2);           
            
        }        

        [Test]                       
        public void When_Add_Data_DataBase_should_be_create_Properly()
        {  
            Assert.NotNull(database);
            Assert.AreEqual(input2.Length, database.Count);

            actual = database.Fetch();
            Assert.AreEqual(input2, actual);          

        }

        [Test]
        public void When_Add_data_bigger_than_16_should_throw_Exception()
        {
            Assert.That
            (
                 Assert.Throws<InvalidOperationException>
                    (
                        () => 
                        {                            
                            database.Add(6);
                        },                      
                    "Array's capacity bigger than 16 integers should throw exception !"

                    ).Message,
                Is.EqualTo("Array's capacity must be exactly 16 integers!"), 
                    "Wrong Massage!"
            );
        }

        [Test]
        public void When_adding_Removing_element_itAdds_Removes_on_Corect_position()
        {
            database.Remove();

            Assert.That(15, Is.EqualTo(database.Count));

            actual = database.Fetch();
            Assert.AreEqual(input2[0..15], actual);

            database.Add(16);

            Assert.That(16, Is.EqualTo(database.Count));

            actual = database.Fetch();
            Assert.AreEqual(input2, actual);
        }

        [Test]
        public void When_Data_is_Empty_Will_throw_Exception()
        {           
            Assert.That
            (
                 Assert.Throws<InvalidOperationException>
                    (
                        () =>
                        {
                            for (int i = 0; i < 17; i++)
                            {
                                database.Remove();
                            }
                        },
                    "Array's capacity is 0 integers should throw exception !"

                    ).Message,
                Is.EqualTo("The collection is empty!"),
                    "Wrong Massage!"
            );
        }
    }
}
