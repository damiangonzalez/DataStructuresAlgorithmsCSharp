using NUnit.Framework;
using NUnitLite;
using System;
using System.Reflection;

// CoderPad example test running with NUnit TestCase attribute
public class Runner {
    public static int Main2(string[] args) {
        return new AutoRun(Assembly.GetCallingAssembly()).Execute(new String[] {"--labels=All"});
    }

    [TestFixture]
    public class Dog {
        public String bark() {
            return "bark";
        }

        [TestCase("bark")]
        [TestCase("bow")]
        [TestCase("sdf")]
        [TestCase("hi")]
        public void TestBarker(string input) {
            Console.WriteLine(input);
            Assert.AreEqual(input, new Dog().bark());
        }
    }
}