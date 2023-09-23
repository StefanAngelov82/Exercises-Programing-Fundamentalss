namespace Animals
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Dictionary<string, Dog> animalDog = new Dictionary<string, Dog>();
           Dictionary<string, Cat> animalCat = new Dictionary<string, Cat>();
           Dictionary<string, Snake> aninalSnake = new Dictionary<string, Snake>();


            string input = String.Empty;

            while ((input = Console.ReadLine()) != "I'm your Huckleberry")
            {
                string[] inputArg = input.Split(' ');

                if (inputArg.Length != 2)
                {
                    if (inputArg[0] == "Dog")
                    {
                        animalDog[inputArg[1]] = Dog.ParseData(inputArg);
                    }
                    else if (inputArg[0] == "Cat")
                    {
                        animalCat[inputArg[1]] = Cat.ParseData(inputArg);
                    }
                    else
                    {
                        aninalSnake[inputArg[1]] = Snake.ParseData(inputArg);
                    }
                }
                else
                {
                    if (animalDog.ContainsKey(inputArg[1]))
                    {
                        animalDog[inputArg[1]].ProduceSound();
                    }
                    else if (animalCat.ContainsKey(inputArg[1]))
                    {
                        animalCat[inputArg[1]].ProduceSound();
                    }
                    else
                    {
                        aninalSnake[inputArg[1]].ProduceSound();
                    }

                }
            }

            foreach (var kvp in animalDog)
            {
                Console.WriteLine($"Dog: {kvp.Value.Name}, Age: {kvp.Value.Age}, Number Of Legs: {kvp.Value.NumberOfLegse}");
            }
            foreach (var kvp in animalCat)
            {
                Console.WriteLine($"Cat: {kvp.Value.Name}, Age: {kvp.Value.Age}, IQ: {kvp.Value.IntelligenceQuotient}");
            }
            foreach (var kvp in aninalSnake)
            {
                Console.WriteLine($"Snake: {kvp.Value.Name}, Age: {kvp.Value.Age}, Cruelty: {kvp.Value.CrueltyCoefficient}");
            }
        }
        class Dog
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int NumberOfLegse { get; set; }

            public Dog(string name, int age, int numberOfLegs)
            {
                Name = name;
                Age = age;
                NumberOfLegse = numberOfLegs;
            }

            public static Dog ParseData(string[] inputArg)
            {
                return new Dog(inputArg[1], int.Parse(inputArg[2]), int.Parse(inputArg[3]));
            }

            public  void ProduceSound()
            {
                Console.WriteLine("I’m a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.");
            }
        }
        class Cat
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int IntelligenceQuotient { get; set; }

            public Cat(string name, int age, int intelligenceQuotient)
            {
                Name = name;
                Age = age;
                IntelligenceQuotient = intelligenceQuotient;
            }

            public static Cat ParseData(string[] inputArg)
            {
                return new Cat(inputArg[1], int.Parse(inputArg[2]), int.Parse(inputArg[3]));
            }

            public void ProduceSound()
            {
                Console.WriteLine("I’m an Aristocat, and I will now produce an aristocratic sound! Myau Myau.");
            }
        }
        class Snake
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int CrueltyCoefficient { get; set; }

            public Snake(string name, int age, int crueltyCoefficient)
            {
                Name = name;
                Age = age;
                CrueltyCoefficient = crueltyCoefficient;
            }

            public static Snake ParseData(string[] inputArg)
            {    
                return new Snake(inputArg[1], int.Parse(inputArg[2]), int.Parse(inputArg[3]));
            }

            public void ProduceSound()
            {
                Console.WriteLine("I’m a Sophistisnake, and I will now produce a sophisticated sound! Honey, I’m home.");
            }
        }
    }
}