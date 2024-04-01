namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        RailwayStation station;
        private string name;
        private string trainName1, trainName2, trainName3;
        private Queue<string> arraiving;
        private Queue<string> deparcharing;


        [SetUp]
        public void Setup()
        {
            name = "Sofia";
            trainName1 = "BMX";
            trainName2 = "Selena";
            trainName3 = "Diana";
            station = new RailwayStation(name);

            station.NewArrivalOnBoard("BMX");
            station.NewArrivalOnBoard("Selena");
            station.NewArrivalOnBoard("Diana");
        }

        [Test]
        public void Test_of_correct_creation_of_station()
        {
            
            Assert.NotNull(station);
            Assert.AreEqual(name, station.Name);
            Assert.NotNull(station.ArrivalTrains);
            Assert.NotNull(station.DepartureTrains);
        }
        [Test]
        public void When_station_name_is_null_correct_Exception_is_thrown()
        {
            name = null;

            Assert.That(Assert.Throws<ArgumentException>(
                        () =>
                        {
                            station = new RailwayStation(name);

                        }, "Name cannot be null or empty!").Message,
                        Is.EqualTo("Name cannot be null or empty!"), "Wrong Massage!");
        }

        [Test]
        public void When_Train_comes_should_be_correctly_added_inQueue()
        {

            Assert.That(station.ArrivalTrains.Count, Is.EqualTo(3));
            Assert.That(station.ArrivalTrains.Dequeue(), Is.EqualTo("BMX"));
            Assert.That(station.ArrivalTrains.Dequeue(), Is.EqualTo("Selena"));
        }
        [Test]
        public void When_train_is_arrives_should_be_correctly_moved_for_depart()
        {
            Assert.IsTrue(station.TrainHasArrived(trainName2) == $"There are other trains to arrive before {trainName2}.");
            Assert.IsTrue(station.TrainHasArrived(trainName1) == $"{trainName1} is on the platform and will leave in 5 minutes.");

            Assert.That(station.ArrivalTrains.Count, Is.EqualTo(2));
            Assert.That(station.DepartureTrains.Count, Is.EqualTo(1));
            Assert.IsFalse(station.ArrivalTrains.Contains(trainName1));
            Assert.IsTrue(station.DepartureTrains.Contains(trainName1));
           
        }

        [Test]
        public void Testing_method_TrainDepart()
        {
            station.TrainHasArrived(trainName1);
            Assert.IsFalse(station.TrainHasLeft(trainName3));
            Assert.IsTrue(station.TrainHasLeft(trainName1));
            Assert.True(station.DepartureTrains.Count == 0);
            
        }
    }
}