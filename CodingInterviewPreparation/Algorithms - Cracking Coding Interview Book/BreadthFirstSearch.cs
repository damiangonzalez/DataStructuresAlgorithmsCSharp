using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

// https://www.csharpstar.com/csharp-breadth-first-search/
namespace Algorithms
{
    public class BreadthFirstSearch
    {
        internal class Employee
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

            public void isEmployeeOf(Employee employee)
            {
                EmployeesList.Add(employee);
            }

            private List<Employee> EmployeesList = new List<Employee>();

            public override string ToString()
            {
                return name;
            }
        }

        public class BreadthFirstAlgorithm
        {
            internal Employee BuildEmployeeGraph()
            {
                Employee Eva = new Employee("Eva");
                Employee Sophia = new Employee("Sophia");
                Employee Brian = new Employee("Brian");

                // Add employees to Eva
                Eva.isEmployeeOf(Sophia);
                Eva.isEmployeeOf(Brian);

                // Add next level of employees
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

            internal Employee Search(Employee root, string nameToSearchFor)
            {
                Queue<Employee> empQueue = new Queue<Employee>();
                HashSet<Employee> hashSetEmployeesWeHaveSeen = new HashSet<Employee>();
                empQueue.Enqueue(root);
                hashSetEmployeesWeHaveSeen.Add(root);

                while (empQueue.Count > 0)
                {
                    Employee currentEmployee = empQueue.Dequeue();
                    if (currentEmployee.name == nameToSearchFor)
                    {
                        return currentEmployee;
                    }

                    foreach (var employee in currentEmployee.Employees)
                    {
                        if (!hashSetEmployeesWeHaveSeen.Contains(employee))
                        {
                            empQueue.Enqueue(employee);
                            hashSetEmployeesWeHaveSeen.Add(employee);
                        }
                    }
                }

                return null;
            }

            internal  void TraverseGraph(Employee root)
            {
                Queue<Employee> traverseOrder = new Queue<Employee>();
                Queue<Employee> empQueue = new Queue<Employee>();
                HashSet<Employee> hashSetEmployeesWeHaveSeen = new HashSet<Employee>();

                empQueue.Enqueue(root);
                hashSetEmployeesWeHaveSeen.Append(root);

                while (empQueue.Count > 0)
                {
                    Employee currentEmp = empQueue.Dequeue();
                    traverseOrder.Enqueue(currentEmp);

                    foreach (Employee currentEmpEmployee in currentEmp.Employees)
                    {
                        if (!hashSetEmployeesWeHaveSeen.Contains(currentEmpEmployee))
                        {
                            empQueue.Enqueue(currentEmpEmployee);
                            hashSetEmployeesWeHaveSeen.Add(currentEmpEmployee);
                        }
                    }
                }

                while (traverseOrder.Count > 0)
                {
                    Employee currentEmpInTraverse = traverseOrder.Dequeue();
                    Console.WriteLine(currentEmpInTraverse);
                }
            }
        }

        [Test] // static void Main(string[] args)
         void MainTest()
        {
            BreadthFirstAlgorithm breadthFirstAlgorithm = new BreadthFirstAlgorithm();
            Employee root = breadthFirstAlgorithm.BuildEmployeeGraph();
            Console.WriteLine("\nTraverse Graph\n------");
            breadthFirstAlgorithm.TraverseGraph(root);
            
            Console.WriteLine("\nSearch Graph\n------");
            Employee EvaSearch = breadthFirstAlgorithm.Search(root, "Eva");
            Console.WriteLine(EvaSearch == null ? "Employee not found" : "Found: " + EvaSearch.name);
 
            Employee BrianSearch = breadthFirstAlgorithm.Search(root, "Brian");
            Console.WriteLine(BrianSearch == null ? "Employee not found" : "Found: " + BrianSearch.name);

            Employee BobSearch = breadthFirstAlgorithm.Search(root, "Bob");
            Console.WriteLine(BobSearch == null ? "Employee not found" : "Found: " + BobSearch.name);
        }
    }
}