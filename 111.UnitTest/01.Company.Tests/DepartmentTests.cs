using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Tests
{
    public class DepartmentTests
    {
        private Department department;
        private Employee employee;
        private Employee employee2;
        private Employee employee3;

        private Guid guid = Guid.Parse("9ff6cacc-784b-4d87-acdb-510dd21313ef");
        private string name = "Penko";
        private decimal salary = 600;
        private string depName = "NAP";

        [SetUp] public void SetUp()
        {
            employee = new Employee(Guid.NewGuid(), name, 1000);
            employee2 = new Employee(Guid.NewGuid(), name + "1", 2000);
            employee3 = new Employee(Guid.NewGuid(), name + "2", 3000);

            department = new Department(depName);
            department.Employees.Add(employee);
            department.Employees.Add(employee2);
            department.Employees.Add(employee3);
        }        

        [Test]

        public void When_Rise_salary_all_Employees_Salary_is_Rised()
        {
            Assert.AreEqual(depName, department.Name);
            Assert.AreEqual(department.Employees.Count, 3);

            department.RaiseSalary(20);

            Assert.AreEqual(1200, employee.Salary);
            Assert.AreEqual(2400, employee2.Salary);
            Assert.AreEqual(3600, employee3.Salary);

            department.FirePeople(employee.Id);

            Assert.AreEqual(department.Employees.Count, 2);
        }

        [Test]

        public void Is_Enployee_Is_Removed()
        {
                        
            department.FirePeople(employee2.Id);

            Assert.AreEqual(department.Employees.Count, 2);
            Assert.IsTrue(!department.Employees.Contains(employee2));
            Assert.IsTrue(employee2.Salary == 0);
        }

        [Test]

        public void When_NoExisting_Employee_is_Fired()
        {            
            Assert.Throws<ArgumentException>(
                () =>
                {
                    department.FirePeople(Guid.NewGuid());
                });
           
        }
    }
}
