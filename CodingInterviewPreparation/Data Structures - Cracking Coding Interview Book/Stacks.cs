using System;
using System.Collections;
using NUnit.Framework;

namespace Algorithms.Data_Structures
{
    public class Stacks
    {
        public static void SimpleStack()
        {
            // Creates and initializes a new Stack.
            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("!");

            // Displays the properties and values of the Stack.
            Console.WriteLine("myStack");
            Console.WriteLine("\tCount:    {0}", myStack.Count);
            Console.Write("\tValues:");
            foreach (Object obj in myStack)
                Console.Write("    {0}", obj);
            Console.WriteLine();
            
            // Removing
            
        }

        [Test]
        public static void TestStacks()
        {
            SimpleStack();
        }
    }
}
