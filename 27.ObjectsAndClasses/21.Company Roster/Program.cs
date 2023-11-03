namespace Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<Employee>> list = new Dictionary<string, List<Employee>>();

            int N = int.Parse(Console.ReadLine());

            DataInput(list, N);

            KeyValuePair<string, List<Employee>> theBest = list. OrderByDescending(x => x.Value.Average(x => x.Salary)).First();

            Console.WriteLine($"Highest Average Salary: {theBest.Key}");

            foreach( Employee emp in theBest.Value.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{emp.Name} {emp.Salary:F2}");
            }

        }

        static void DataInput(Dictionary<string, List<Employee>> list, int N)
        {
            for (int i = 0; i < N; i++)
            {
                Employee emp = Employee.DataParse(Console.ReadLine());

                if (!list.ContainsKey(emp.Department))
                {
                    list[emp.Department] = new List<Employee>();
                }

                list[emp.Department].Add(emp);
            }
        }
    }
    class Employee
    {

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, double salaty, string department)
        {
            this.Name = name;
            this.Salary = salaty;
            this.Department = department;
        }
        public static Employee DataParse(string input)
        {
            string[] inputArg = input.Split();

            string name = inputArg[0];
            double salary = double.Parse(inputArg[1]);
            string department = inputArg[2];

            return new Employee(name, salary, department);
        }

    }
}