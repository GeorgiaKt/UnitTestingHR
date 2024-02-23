using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRLib.HRLib;
using System.Collections.Specialized;

namespace UnitTestHRLib
{
    [TestClass]
    public class UnitTestInfoEmployee
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

            object[,] testcases5 =
            {
                { 17, emp1 , 29 , 14 , msg },
                { 18, emp2 , 24 , 9  , msg },
                { 19, emp3 , 27 , 14 , msg },
                { 20, emp4 , 39 , 12 , msg },
                { 21, emp5 , 52 , 12 , msg },
                { 22, emp6 , 35 , 12 , msg },
                { 23, emp7 , 25 , 4  , msg },
                { 24, emp8 , 34 , 3  , msg }
            };

            int i = 0;
            bool failed = false;

            for (i = 0; i < testcases5.GetLength(0); i++)
            {
                try
                {
                    int Age = 1;

                    int YearsOfExperience = -1;

                    hr.InfoEmployee((Employee)testcases5[i,1], ref Age, ref YearsOfExperience);

                    Assert.AreEqual((int)testcases5[i, 2], Age);
                    Assert.AreEqual((int)testcases5[i, 3], YearsOfExperience);

                }
                catch (Exception e)
                {

                    failed = true;

                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ", (int)testcases5[i, 0], (string)testcases5[i, 4], e.Message);

                };
            };

            if (failed) Assert.Fail();

        }
    }
}
