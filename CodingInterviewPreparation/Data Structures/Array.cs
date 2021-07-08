using System;
using NUnit.Framework;
using System.Linq;

namespace Algorithms.Data_Structures
{
    public class Array
    {
        string[] cars = new[] {"Volvo", "BMW", "Ford", "Mazda"};
        int[] myNums = new[] {10, 20, 30, 40};

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OperateOnStringArray()
        {
            Console.WriteLine(cars[0]); // Print "Volvo"

            cars[0] = "Opel";
            Console.WriteLine(cars[0]); // Print "Opel"

            Console.WriteLine(cars.Length); // Print 4

            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }

            System.Array.Sort(cars);
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i]);
            }

            Assert.Pass();
        }

        [Test]
        public void LinqOperationsOnStringArray()
        {
            Console.WriteLine(myNums.Max());
            Console.WriteLine(myNums.Min());
            Console.WriteLine(myNums.Sum());
            Console.WriteLine(myNums.Average());
        }
    }
}