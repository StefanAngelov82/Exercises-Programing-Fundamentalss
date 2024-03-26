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
        private  int numberOfPersons;
        

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

        public void When_Add_Or_Remove_Person_Data_should_Be_correct_exception_for_missing_person_should_be_expected()
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
            Assert.Throws<>
        }

         
    }
}