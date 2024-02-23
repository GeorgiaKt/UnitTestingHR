using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRLib.HRLib;
using System.Collections.Specialized;

namespace UnitTestHRLib
{
    [TestClass]
    public class UnitTestLiveInAthens
    {
        const string msg = "Password did not expected  ";

        [TestMethod]
        public void TestMethod1()
        {
            HRLib.HRLib hr = new HRLib.HRLib();

            Employee emp1 = new Employee("Vaggelis@", "2108088661", "6984285123", new DateTime(1995, 3, 1), new DateTime(2010, 4, 1));
            Employee emp2 = new Employee("Johnh", "2208088661", "6934285123", new DateTime(2000, 5, 1), new DateTime(2015, 4, 1));
            Employee emp3 = new Employee("Georgiahh", "2308088661", "6944285123", new DateTime(1997, 6, 1), new DateTime(2010, 4, 1));
            Employee emp4 = new Employee("Antonis23", "2408088661", "6954285123", new DateTime(1985, 3, 1), new DateTime(2012, 4, 1));
            Employee emp5 = new Employee("Dimitri", "2508088661", "6974285123", new DateTime(1972, 3, 1), new DateTime(2020, 4, 1));
            Employee emp6 = new Employee("Eleni", "2608088661", "6934285123", new DateTime(1991, 3, 1), new DateTime(2020, 4, 1));
            Employee emp7 = new Employee("Artemis", "2708088661", "6984285123", new DateTime(1999, 3, 1), new DateTime(2022, 4, 1));
            Employee emp8 = new Employee("Spiros", "2808088661", "6484285123", new DateTime(1990, 3, 1), new DateTime(2021, 4, 1));

            Employee[] Employees = { emp1, emp2, emp3, emp4, emp5, emp6, emp7, emp8 };

            object[,] testcases6 =
            {
                { 1, Employees , 1 , msg }
            };

            int i = 0;
            bool failed = false;

            try
            {

                Assert.AreEqual((int)testcases6[i, 2], hr.LiveInAthens((Employee[])testcases6[i, 1]));

            }
            catch (Exception e)
            {

                failed = true;

                Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ", (int)testcases6[i, 0], (string)testcases6[i, 3], e.Message);

            };

            if (failed) Assert.Fail();

        }
    }
}
