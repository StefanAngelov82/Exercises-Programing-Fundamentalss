using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Tests
{
    public class EmployeeTests
    {
        private Guid guid = Guid.Parse("9ff6cacc-784b-4d87-acdb-510dd21313ef");
        private string name = "Penko";
        private decimal salary = 600;

        [Test]

        public void During_Creation_ID_Should_be_Set_Correctly()
        {
            Employee employee = new Employee();

            Assert.AreNotEqual(Guid.Empty, employee.Id);            

        }

        [Test]

        public void Creating_Employee_Data_Should_Be_Set_Correctly()
        {
            Employee employee = new Employee(guid, name, 600);

            Assert.AreEqual(guid, employee.Id);
            Assert.AreEqual(name, employee.Name);
            Assert.AreEqual(salary, employee.Salary);
        }

        [Test]

        public void When_printing_Format_should_Be_Correct()
        {
            Employee employee = new Employee(guid, name, salary);

            Assert.AreEqual($"{guid} - {name} has salary {salary}", employee.ToString());
        }
    }
}
