using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HRLib;

namespace UnitTestHRLib
{
    [TestClass]
    public class UnitTest1
    {
        const string msg1 = "Name is not valid if equals John or Georgia";

        [TestMethod]
        public void TestMethod1()
        {
            HRLib.HRLib hr = new HRLib.HRLib();

            HRLib.HRLib.Employee emp1 = new HRLib.HRLib.Employee("Vaggelis", "2108088661", "6984285123", new DateTime(1995, 3, 1), new DateTime(2010, 4, 1));
            HRLib.HRLib.Employee emp2 = new HRLib.HRLib.Employee("Johnh", "2208088661", "6934285123", new DateTime(2000, 5, 1), new DateTime(2015, 4, 1));
            HRLib.HRLib.Employee emp3 = new HRLib.HRLib.Employee("Georgiahh", "2308088661", "6944285123", new DateTime(1997, 6, 1), new DateTime(2010, 4, 1));
            HRLib.HRLib.Employee emp4 = new HRLib.HRLib.Employee("Antonis", "2408088661", "6954285123", new DateTime(1985, 3, 1), new DateTime(2012, 4, 1));
            HRLib.HRLib.Employee emp5 = new HRLib.HRLib.Employee("Dimitri", "2508088661", "6974285123", new DateTime(1972, 3, 1), new DateTime(2020, 4, 1));
            HRLib.HRLib.Employee emp6 = new HRLib.HRLib.Employee("Eleni", "2608088661", "6934285123", new DateTime(1991, 3, 1), new DateTime(2020, 4, 1));
            HRLib.HRLib.Employee emp7 = new HRLib.HRLib.Employee("Artemis", "2708088661", "6984285123", new DateTime(1999, 3, 1), new DateTime(2022, 4, 1));
            HRLib.HRLib.Employee emp8 = new HRLib.HRLib.Employee("Spiros", "2808088661", "6484285123", new DateTime(1990, 3, 1), new DateTime(2021, 4, 1));


            object[,] testcases =
            {
                { 1, emp1, true, msg1 },
                { 2, emp2, true, msg1 },
                { 3, emp3, true, msg1 },
                { 4, emp4, true, msg1 },
                { 5, emp5, true, msg1 },
                { 6, emp6, true, msg1 },
                { 7, emp7, true, msg1 },
                { 8, emp8, true, msg1 }
            };

            int i = 0;
            bool failed = false;

            for(i=0; i < testcases.Length; i++)
            {
                try 
                {
                    Assert.AreEqual(testcases[i,2], hr.ValidName(((HRLib.HRLib.Employee)testcases[i,1]).Name));
                }
                catch(Exception e) 
                { 
                    
                    failed = true;

                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ", testcases[i,0], testcases[i,3], e.Message);
                
                };
            };

            if (failed) Assert.Fail();

        }
    }
}
