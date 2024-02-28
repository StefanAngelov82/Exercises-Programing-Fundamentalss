using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
		private string firstName;
        private string lastName;
		private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
			this.Salary = salary;
        }

        public string FirstName
		{
			get { return firstName; }

			private set
			{ 
				if (value.Length < 3)
				{
					throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
				}

				firstName = value;
			}
		}		

		public string LastName
		{
			get { return lastName; }

			private set 
			{ 
				if (value.Length < 3)
				{
					throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
				}

				lastName = value; 
			}
		}	

		public int Age
		{
			get { return age; }

			private set 
			{
				if (value <= 0 )
				{
					throw new ArgumentException("Age cannot be zero or a negative integer!");
				}

				age = value; 
			}
		}		

		public decimal Salary
		{
			get { return salary; }

			private set 
			{
                if ( value < 650)
                {
					throw new ArgumentException("Salary cannot be less than 650 leva!");
                }

                salary = value;
			}
		}

		public void IncreaseSalary(decimal percentage)
		{
			if (age < 30)
				percentage = percentage / 2;
			
			Salary += ((percentage)/100) * Salary;
		}


        public override string ToString()
        {
			return $"{this.firstName} {this.lastName} receives {this.salary:F2} leva."; 
        }

    }
}
