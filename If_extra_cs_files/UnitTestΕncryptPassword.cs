using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRLib.HRLib;
using System.Collections.Specialized;

namespace UnitTestHRLib
{
    [TestClass]
    public class UnitTestΕncryptPassword
    {
        const string msg = "Password did not expected  ";

        [TestMethod]
        public void TestMethod1()
        {
            HRLib.HRLib hr = new HRLib.HRLib();

            object[,] testcases3 =
            {
                { 17, "Az15ghg58#$5"   , "Fe15lml58#$5" , msg },
                { 18, "45456"          , "45456"        , msg },
                { 19, "Afhffifi"       , "Fkmkknkn"     , msg },
                { 20, "123456789101"   , "123456789101" , msg },
                { 21, "Azhfioshukhk"   , "Femkntxmzpmp" , msg },
                { 22, "zhfiorghdygc"   , "emkntwlmidlh" , msg },
                { 23, "E&#156489631"   , "J&#156489631" , msg },
                { 24, "Afjh856#gjd2"   , "Fkom856#loi2" , msg }
            };

            int i = 0;
            bool failed = false;

            for (i = 0; i < testcases3.GetLength(0); i++)
            {
                try
                {
                    string ΕncryptedPW = "";

                    hr.ΕncryptPassword((string)testcases3[i,1], ref ΕncryptedPW);

                    Assert.AreEqual(ΕncryptedPW, (string)testcases3[i,2]);
                }
                catch (Exception e)
                {

                    failed = true;

                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ", (int)testcases3[i, 0], (string)testcases3[i, 3], e.Message);

                };
            };

            if (failed) Assert.Fail();

        }
    }
}
