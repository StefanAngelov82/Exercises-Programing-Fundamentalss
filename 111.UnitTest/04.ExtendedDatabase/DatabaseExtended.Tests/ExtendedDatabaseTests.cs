namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Text;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database dataBase;
        private Person[] peoples;
        private Person expectedPerson;
        private Person actualPerson;
        private long personId;
        private string personName;
        private int numberOfPersons;


        [SetUp]
        public void SetUp()
        {

            personId = 9999999999;
            personName = "person";

        }

        public Person[] GetData()
        {
            peoples = new Person[numberOfPersons];

            for (int i = 0; i < numberOfPersons; i++)
            {
                peoples[i] = new Person((personId + i), (personName + $"{i}"));
            }

            return peoples;
        }

        [Test]
        public void When_give_name_and_Id_Person_should_be_Created()
        {
            string name = "Ivan";
            long id = 1234567899999;

            Person person = new Person(id, name);

            Assert.NotNull(person);
            Assert.AreEqual(id, person.Id);
            Assert.AreEqual(name, person.UserName);
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(16)]
        public void When_we_add_Data_new_dataBBase_will_be_created(int numberOfPersons)
        {
            this.numberOfPersons = numberOfPersons;

            peoples = GetData();
            dataBase = new Database(peoples);

            Assert.NotNull(dataBase);
            Assert.That(numberOfPersons, Is.EqualTo(dataBase.Count));

            actualPerson = dataBase.FindByUsername("person0");
            expectedPerson = new Person(personId, personName + "0");

            Assert.AreEqual(expectedPerson.Id, actualPerson.Id);
            Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName);

            if (numberOfPersons >= 4)
            {
                actualPerson = dataBase.FindById(personId + (numberOfPersons - 1));
                expectedPerson = new Person(personId + (numberOfPersons - 1), (personName + $"{(numberOfPersons - 1)}"));

                Assert.AreEqual(expectedPerson.Id, actualPerson.Id);
                Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName);
            }
        }

        [Test]
        public void When_we_add_more_than_16_Persons_should_Throw_Exception()
        {
            this.numberOfPersons = 17;

            peoples = GetData();

            Assert.That(
                Assert.Throws<ArgumentException>(
                        () =>
                        {
                            dataBase = new Database(peoples);
                        }, "If provided data is not in range [0..16], Exception should be expected!"
                 ).Message,
            Is.EqualTo("Provided data length should be in range [0..16]!"), "Wrong message!"
                );
        }

        [Test]

        public void When_Add_Or_Remove_Person_Data_should_Be_correct_exception_for_missing_person_OR_doubling_Person_should_be_expected()
        {
            this.numberOfPersons = 14;

            peoples = GetData();
            dataBase = new Database(peoples);

            expectedPerson = new Person(personId + 14, personName + $"14");
            dataBase.Add(expectedPerson);

            Assert.That(15, Is.EqualTo(dataBase.Count));

            actualPerson = dataBase.FindByUsername($"{personName + $"14"}");

            Assert.AreEqual(expectedPerson.Id, actualPerson.Id);
            Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName);          

            dataBase.Remove();

            Assert.That(14, Is.EqualTo(dataBase.Count));

            Assert.That
            (
                Assert.Throws<InvalidOperationException>
                (
                    () =>
                    {
                        expectedPerson = dataBase.FindByUsername("person14");

                    }, "No user is present by this username, exception should be expected"

               ).Message,
             Is.EqualTo("No user is present by this username!"), "Wrong massage"
             );

            Assert.That
            (
                Assert.Throws<InvalidOperationException>
                (
                    () =>
                    {
                        expectedPerson = dataBase.FindById(9999999999 + 14);

                    }, "No user is present by this ID, exception should be expected"

               ).Message,
             Is.EqualTo("No user is present by this ID!"), "Wrong massage"
             );
        }

        [Test]

        public void Exception_When_Adding_existing_Person()
        {
            this.numberOfPersons = 14;

            peoples = GetData();
            dataBase = new Database(peoples);

            expectedPerson = new Person(personId + 14, personName + $"14");
            dataBase.Add(expectedPerson);            

            Assert.That
            (
                Assert.Throws<InvalidOperationException>
                (
                    () =>
                    {
                        dataBase.Add(expectedPerson);

                    }, "There is already user with this username!, exception should be expected"

               ).Message,
             Is.EqualTo("There is already user with this username!"), "Wrong massage"
             );

            expectedPerson = new Person(personId + 14, "Spas");

            Assert.That
          (
              Assert.Throws<InvalidOperationException>
              (
                  () =>
                  {
                      dataBase.Add(expectedPerson);

                  }, "There is already user with this Id!, exception should be expected"

             ).Message,
           Is.EqualTo("There is already user with this Id!"), "Wrong massage"
           );
        }

        [Test]
        public void When_remove_person_in_Empty_data_Should_expect_Exception()
        {
            this.numberOfPersons = 0;

            peoples = GetData();
            dataBase = new Database(peoples);

            Assert.Throws<InvalidOperationException>
              (
                  () =>
                  {
                      dataBase.Remove();

                  }, "Database is empty, exception should be expected"

             );
        }

        [Test]

        public void When_enter_Person_with_missing_name()
        {
            this.numberOfPersons = 0;

            peoples = GetData();
            dataBase = new Database(peoples);

            Assert.That
          (
              Assert.Throws<ArgumentNullException>
              (
                  () =>
                  {
                      expectedPerson = dataBase.FindByUsername(null);

                  }, "Username parameter is null!, exception should be expected"

             ).Message,
           Is.EqualTo("Value cannot be null. (Parameter 'Username parameter is null!')"), "Wrong massage**"
           );
        }

        [Test]
        public void When_Adding_Person_with_negative_Id()
        {
            this.numberOfPersons = 3;

            peoples = GetData();
            dataBase = new Database(peoples);

            Assert.That
         (
             Assert.Throws<ArgumentOutOfRangeException>
             (
                 () =>
                 {
                     expectedPerson = dataBase.FindById(-3);

                 }, "Id should be a positive number!, exception should be expected"

            ).Message,
          Is.EqualTo("Specified argument was out of the range of valid values. (Parameter 'Id should be a positive number!')"), "Wrong massage**"
          );
        }
        [Test]

        public void When_Adding_more_than_16_person_DB()
        {
            this.numberOfPersons = 16;

            peoples = GetData();
            dataBase = new Database(peoples);
            expectedPerson = new Person(personId + 15, personName + $"15");


            Assert.That
        (
            Assert.Throws<InvalidOperationException>
            (
                () =>
                {
                    dataBase.Add(expectedPerson);

                }, "Array's capacity must be exactly 16 integers!"

           ).Message,
         Is.EqualTo("Array's capacity must be exactly 16 integers!"), "Wrong massage**"
         );
        }
    }
}