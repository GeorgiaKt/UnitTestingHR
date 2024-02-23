using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRLib.HRLib;
using System.Collections.Specialized;

namespace UnitTestHRLib
{
    [TestClass]
    public class UnitTestCheckPhone
    {
        const string msg = "Password did not expected  ";

        [TestMethod]
        public void TestMethod1()
        {
            HRLib.HRLib hr = new HRLib.HRLib();

            object[,] testcases4 =
            {
                { 17, "2108088661"   , 0 , "21"       , msg },
                { 18, "6934285123"   , 1 , "Nova"     , msg },
                { 19, "2308088661"   , 0 , "23"       , msg },
                { 20, "6954285123"   , 1 , "Vodafone" , msg },
                { 21, "2508088661"   , 0 , "25"       , msg },
                { 22, "6934285123"   , 1 , "Nova"     , msg },
                { 23, "2708088661"   , 0 , "27"       , msg },
                { 24, "6484285123"   , 1 , "-1"       , msg }
            };

            int i = 0;
            bool failed = false;

            for (i = 0; i < testcases4.GetLength(0); i++)
            {
                try
                {
                    int TypePhone = 2;

                    string InfoPhone = "";

                    hr.CheckPhone((string)testcases4[i, 1], ref TypePhone, ref InfoPhone);

                    Assert.AreEqual((int)testcases4[i, 2], TypePhone);
                    Assert.AreEqual((string)testcases4[i, 3], InfoPhone);

                }
                catch (Exception e)
                {

                    failed = true;

                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ", (int)testcases4[i, 0], (string)testcases4[i, 4], e.Message);

                };
            };

            if (failed) Assert.Fail();

        }
    }
}
