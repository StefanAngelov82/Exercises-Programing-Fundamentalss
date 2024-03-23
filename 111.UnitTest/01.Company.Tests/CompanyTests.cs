using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Tests
{
    public class CompanyTests
    {
        private Department department;
        private Employee employee;
        private Employee employee2;
        private Employee employee3;
        private Company company;

        private Guid guid = Guid.Parse("9ff6cacc-784b-4d87-acdb-510dd21313ef");
        private string name = "Penko";
        private decimal salary = 600;
        private string depName = "NAP";

        [SetUp]
        public void SetUp()
        {
            company = new Company();
            employee = new Employee(Guid.NewGuid(), name, 1000);
            employee2 = new Employee(Guid.NewGuid(), name + "1", 2000);
            employee3 = new Employee(Guid.NewGuid(), name + "2", 3000);

            department = new Department(depName);
            department.Employees.Add(employee);
            department.Employees.Add(employee2);
            department.Employees.Add(employee3);

            company.Departments.Add(department);    
        }

        [Test]

        public void When_Rise_salary_ToAll_Departments_Is_ShouldHaveCorectData()
        {
            company.RaiseSalary(20);

            //Mocking
        }
    }
}
