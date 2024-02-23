using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRLib.HRLib;
using System.Collections.Specialized;

namespace UnitTestHRLib
{
    [TestClass]
    public class UnitTestValidPassword
    {
        const string msg = "Password must not contain ";

        [TestMethod]
        public void TestMethod1()
        {
            HRLib.HRLib hr = new HRLib.HRLib();

            object[,] testcases = 
            {
                { 9, "Az15ghg58#$5"   , true  , msg },
                { 10, "45456"          , false , msg },
                { 11, "Afhffifi"       , false , msg },
                { 12, "123456789101"   , false , msg },
                { 13, "Azhfioshukhk"   , false , msg },
                { 14, "zhfiorghdygc"   , false , msg },
                { 15, "E&#156489631"   , true  , msg },
                { 16, "Afjh856#gjd2"   , true  , msg }
            };

            int i = 0;
            bool failed = false;

            for (i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testcases[i, 2], hr.ValidPassword((string)testcases[i, 1]));
                }
                catch (Exception e)
                {

                    failed = true;

                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ", (int)testcases[i, 0], (string)testcases[i, 3], e.Message);

                };
            };

            if (failed) Assert.Fail();

        }
    }
}
