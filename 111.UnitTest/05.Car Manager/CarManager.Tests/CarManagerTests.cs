namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelAmount;
        private double fuelCapacity;


        [SetUp]
        public void SetUp()
        {
            make = "BMV";
            model = "X6";
            fuelConsumption = 1;
            fuelAmount = 0;
            fuelCapacity = 10;
        }
        [Test]
        public void When_create_car_Data_should_be_correct()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.IsNotNull(car);
            Assert.True(car.Make == "BMV");
            Assert.True(car.Model == "X6");
            Assert.True(car.FuelConsumption == 1);
            Assert.True(car.FuelAmount == 0);
            Assert.True(car.FuelCapacity == 10);
        }
        [Test]
        public void When_we_test_car_parameters_constrains_Should_expect_Exceptions()
        {
            Assert.That
            (
                 Assert.Throws<ArgumentException>
                    (
                        () =>
                        {
                            car = new Car(null, model, fuelConsumption, fuelCapacity);
                        },
                    "Make cannot be null or empty!, exception should be expected"

                    ).Message,
                 Is.EqualTo("Make cannot be null or empty!"),
                    "Wrong Massage!"
            );

            Assert.That
            (
                 Assert.Throws<ArgumentException>
                    (
                        () =>
                        {
                            car = new Car(make, null, fuelConsumption, fuelCapacity);
                        },
                    "Model cannot be null or empty!, exception should be expected"

                    ).Message,
                 Is.EqualTo("Model cannot be null or empty!"),
                    "Wrong Massage!"
            );

            Assert.That
            (
                 Assert.Throws<ArgumentException>
                    (
                        () =>
                        {
                            car = new Car(make, model, 0, fuelCapacity);
                        },
                    "Fuel consumption cannot be zero or negative!, exception is expected"

                    ).Message,
                 Is.EqualTo("Fuel consumption cannot be zero or negative!"),
                    "Wrong Massage!"
            );

           Assert.That
           (
                Assert.Throws<ArgumentException>
                   (
                       () =>
                       {
                           car = new Car(make, model, fuelConsumption, 0);
                           
                       },
                   "Fuel capacity cannot be zero or negative!, exception is expected"

                   ).Message,
                Is.EqualTo("Fuel capacity cannot be zero or negative!"),
                   "Wrong Massage!"
           );
        }

        [Test]
        [TestCase(5)]
        [TestCase(12)]
        [TestCase(-5)]
        public void When_car_is_refuels_All_calculations_are_correct(int fuelToRefuel)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            if (fuelToRefuel <= 0)
            {
               Assert.That
               (
                    Assert.Throws<ArgumentException>
                       (
                           () =>
                           {
                               car.Refuel(fuelToRefuel);
                           },
                       "Fuel amount cannot be zero or negative!d, exception is expected"

                       ).Message,
                    Is.EqualTo("Fuel amount cannot be zero or negative!"),
                       "Wrong Massage!"
               );

                return;
            }

            car.Refuel(fuelToRefuel);

            if (fuelToRefuel <= car.FuelCapacity )
            {                 
                Assert.That(fuelToRefuel, Is.EqualTo(car.FuelAmount));
            }
            else if (fuelToRefuel > car.FuelCapacity)
            {
                Assert.That(car.FuelCapacity, Is.EqualTo(car.FuelAmount));
            }
        }

        [Test]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(3000)]

        public void Testing_Drive(int distance)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);
           

            if (distance > 1000)
            {
                Assert.That
               (
                    Assert.Throws<InvalidOperationException>
                       (
                           () =>
                           {
                               car.Drive(distance);
                           },
                       "You don't have enough fuel to drive!, exception is expected"

                       ).Message,
                    Is.EqualTo("You don't have enough fuel to drive!"),
                       "Wrong Massage!"
               );

                return;
            }

            car.Drive(distance);

            if (distance == 100)
            {
                Assert.That(9, Is.EqualTo(car.FuelAmount));
            }

            if (distance == 1000)
            {
                Assert.That(0, Is.EqualTo(car.FuelAmount));
            }
            


        }   

    }
    
}