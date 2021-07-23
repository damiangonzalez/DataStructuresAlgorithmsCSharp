using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.csharpstar.com/csharp-depth-first-seach-using-list/
    public class DepthFirstSearch
    {
        public class Employee
        {
            public Employee(string name)
            {
                this.name = name;
            }

            public string name { get; set; }

            public List<Employee> Employees
            {
                get { return EmployeesList; }
            }

            public void isEmployeeOf(Employee e)
            {
                EmployeesList.Add(e);
            }

            List<Employee> EmployeesList = new List<Employee>();

            public override string ToString()
            {
                return name;
            }
        }

        public class DepthFirstAlgorithm
        {
            public Employee BuildEmployeeGraph()
            {
                Employee Eva = new Employee("Eva");
                Employee Sophia = new Employee("Sophia");
                Employee Brian = new Employee("Brian");
                Eva.isEmployeeOf(Sophia);
                Eva.isEmployeeOf(Brian);

                Employee Lisa = new Employee("Lisa");
                Employee Tina = new Employee("Tina");
                Employee John = new Employee("John");
                Employee Mike = new Employee("Mike");
                Sophia.isEmployeeOf(Lisa);
                Sophia.isEmployeeOf(John);
                Brian.isEmployeeOf(Tina);
                Brian.isEmployeeOf(Mike);

                return Eva;
            }

            public Employee Search(Employee root, string nameToSearchFor)
            {
                if (root.name == nameToSearchFor)
                {
                    return root;
                }

                Employee foundEmployee = null;

                foreach (Employee employee in root.Employees)
                {
                    foundEmployee = Search(employee, nameToSearchFor);
                    if (foundEmployee != null)
                        break;
                }

                return foundEmployee;
            }

            public void Traverse(Employee root)
            {
                Console.WriteLine(root.name);
                foreach (Employee employee in root.Employees)
                {
                    Traverse(employee);
                }
            }
        }

        [Test] // static void Main(string[] args)
        public void MainTest()
        {
            DepthFirstAlgorithm b = new DepthFirstAlgorithm();
            Employee root = b.BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n------");
            b.Traverse(root);

            Console.WriteLine("\nSearch in Graph\n------");
            Employee e = b.Search(root, "Eva");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Brian");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Soni");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
        }
    }
}