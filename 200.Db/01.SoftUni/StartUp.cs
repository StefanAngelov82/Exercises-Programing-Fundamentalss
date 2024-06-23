using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext context = new SoftUniContext();
            
            Console.WriteLine(GetEmployeesInPeriod(context));

        }
        public static string aaAddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new();            

            foreach (var employee in context.Employees
                    .Select(e => new
                    {
                        e.FirstName,                        
                        e.LastName,
                        e.MiddleName,
                        e.JobTitle,
                        e.Salary

                    }).ToList())
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }                         
            
            return sb.ToString().TrimEnd();
        }


        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var employee in context.Employees
                    .Where(e => e.Salary > 50_000)
                    .Select(e => new 
                    {
                        e.FirstName,
                        e.Salary

                    })
                    .OrderBy(e => e.FirstName)
                    .ToList())
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach(var employee in context.Employees
                    
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.Salary,
                        e.Department
                    })
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e =>e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .ToList())
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAddress = new Address() 
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            if(employee != null)
            {
                employee.Address = newAddress;
                context.SaveChanges();
            }

            foreach (var emp in context.Employees
                .OrderByDescending(a => a.Address.AddressId)
                .Take(10)
                .Select(e => new
                {
                    e.Address
                })
                
                .ToList())
            {
                sb.AppendLine(emp.Address.AddressText);
            }

            Console.WriteLine();
            foreach (var emp in context.Addresses.OrderByDescending(e => e.AddressId))
            {
                Console.WriteLine(emp.AddressText);
            }

            return sb.ToString().Trim ();
            
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    EmployeeNames = $"{e.FirstName} {e.LastName}",                      
                    ManagerNames = (e.Manager != null) ? $"{e.Manager.FirstName} {e.Manager.LastName}" : "N/A",
                    Projects = e.EmployeesProjects
                                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                                 ep.Project.StartDate.Year <= 2003 )
                                    .Select(ep => new 
                                    {
                                        ProjectName = ep.Project.Name,
                                        ProjecStartdate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                                        ProjectEndDate =  ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")  : "not finished"
                                    })

                }).Take(10)
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeNames} - Manager: {emp.ManagerNames}");

                if (emp.Projects.Count() != 0)
                {
                    foreach (var project in emp.Projects)
                    {
                        sb.AppendLine($"--{project.ProjectName} - {project.ProjecStartdate} - {project.ProjectEndDate}");
                    }
                }
            }
            return sb.ToString().Trim();
        }
    }

    
}
