using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRLib.HRLib;
using System.Collections.Specialized;

namespace UnitTestHRLib
{
    [TestClass]
    public class UnitTestHRLib
    {
        const string msg1 = "Must be Name [space] Surname. Must not contain Numbers and Symbols.";
        const string msg2 = "Password must be 12 characters, starts with Head Letter, must contain at least one, letter, number, symbol and ends with Number.";
        const string msg3 = "Password Encryption works with Ceasar Cipher by 5 position shifting.";
        const string msg4 = "All phone number must be 10 numbers. Home Numbers must start with 2 and Mobile Numbers must start with 69.";
        const string msg5 = "Employees Age and Years of Experience is calculated by subtracting it from the running year.";
        const string msg6 = "LiveInAthens uses the Home Number to check if an Employee Lives in Athens.";

        [TestMethod]
        public void TestMethodValidName()
        {
            HRLib.HRLib hr = new HRLib.HRLib();

            object[,] testcases =
            {
                { 1, "JohnSmith"        , false , msg1  },
                { 2, "Mary Johnson"     , true  , msg1, },
                { 3, "David Lee"        , true  , msg1, },
                { 4, "Emily Chen23@"    , false , msg1, },
                { 5, "Michael Davis"    , true  , msg1, },
                { 6, "Sarah Wilson"     , true  , msg1, },
                { 7, "Christopher Brown", true  , msg1, },
                { 8, "Jennifer Martinez", true  , msg1, }
            };

            int i = 0;
            bool failed = false;

            for (i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testcases[i, 2], hr.ValidName((string)testcases[i, 1]));
                }
                catch (Exception e)
                {

                    failed = true;

                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ", (int)testcases[i, 0], (string)testcases[i, 3], e.Message);

                };
            };

            if (failed) Assert.Fail();

        }

        [TestMethod]
        public void TestMethodValidPassword()
        {
            HRLib.HRLib hr = new HRLib.HRLib();

            object[,] testcases2 =
            {
                { 1, "Az15ghg58#$5"   , true  , msg2 },
                { 2, "45456"          , false , msg2 },
                { 3, "Afhffifi"       , false , msg2 },
                { 4, "123456789101"   , false , msg2 },
                { 5, "Azhfioshu&55"   , true , msg2 },
                { 6, "zhfiorghdygc"   , false , msg2 },
                { 7, "E&#156489631"   , false , msg2 },
                { 8, "Afjh856#gjd22"   , true  , msg2 }
            };

            int i = 0;
            bool failed = false;

            for (i = 0; i < testcases2.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testcases2[i, 2], hr.ValidPassword((string)testcases2[i, 1]));
                }
                catch (Exception e)
                {

                    failed = true;

                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ", (int)testcases2[i, 0], (string)testcases2[i, 3], e.Message);

                };
            };

            if (failed) Assert.Fail();

        }

        [TestMethod]
        public void TestMethodΕncryptPassword()
        {
            HRLib.HRLib hr = new HRLib.HRLib();

            object[,] testcases3 =
            {
                { 1, "Az15ghg58#$5"   , "Fe15lml58#$5" , msg3 },
                { 2, "45456"          , "45456"        , msg3 },
                { 3, "Afhffifi"       , "Fkmkknkn"     , msg3 },
                { 4, "123456789101"   , "123456789101" , msg3 },
                { 5, "Azhfioshukhk"   , "Femkntxmzpmp" , msg3 },
                { 6, "zhfiorghdygc"   , "emkntwlmidlh" , msg3 },
                { 7, "E&#156489631"   , "J&#156489631" , msg3 },
                { 8, "Afjh856#gjd2"   , "Fkom856#loi2" , msg3 }
            };

            int i = 0;
            bool failed = false;

            for (i = 0; i < testcases3.GetLength(0); i++)
            {
                try
                {
                    string ΕncryptedPW = "";

                    hr.ΕncryptPassword((string)testcases3[i, 1], ref ΕncryptedPW);

                    Assert.AreEqual(ΕncryptedPW, (string)testcases3[i, 2]);
                }
                catch (Exception e)
                {

                    failed = true;

                    Console.WriteLine("Failed Test Case: {0} \n \t Hint: {1} \n \t Reason: {2} ", (int)testcases3[i, 0], (string)testcases3[i, 3], e.Message);

                };
            };

            if (failed) Assert.Fail();

        }

        [TestMethod]
        public void TestMethodCheckPhone()
        {
            HRLib.HRLib hr = new HRLib.HRLib();

            object[,] testcases4 =
            {
                { 1, "2108088661"   , 0 , "21"       , msg4 },
                { 2, "6934285123"   , 1 , "Nova"     , msg4 },
                { 3, "2308088661"   , 0 , "23"       , msg4 },
                { 4, "6954285123"   , 1 , "Vodafone" , msg4 },
                { 5, "2508088661"   , 0 , "25"       , msg4 },
                { 6, "6934285123"   , 1 , "Nova"     , msg4 },
                { 7, "2708088661"   , 0 , "27"       , msg4 },
                { 8, "6484285123"   , -1, "-1"       , msg4 }
            };

            int i = 0;
            bool failed = false;

            for (i = 0; i < testcases4.GetLength(0); i++)
            {
                try
                {
                    int TypePhone = 2;

                    string InfoPhone = "2";

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

        [TestMethod]
        public void TestMethodInfoEmployee()
        {
            HRLib.HRLib hr = new HRLib.HRLib();

            Employee emp1 = new Employee("JohnSmith", "2108088661", "6984285123", new DateTime(1995, 3, 1), new DateTime(2010, 4, 1));
            Employee emp2 = new Employee("Mary Johnson", "2208088661", "6934285123", new DateTime(2000, 5, 1), new DateTime(2015, 4, 1));
            Employee emp3 = new Employee("David Lee", "2308088661", "6944285123", new DateTime(1997, 6, 1), new DateTime(2010, 4, 1));
            Employee emp4 = new Employee("Emily Chen23@", "2408088661", "6954285123", new DateTime(1985, 3, 1), new DateTime(2012, 4, 1));
            Employee emp5 = new Employee("Michael Davis", "2508088661", "6974285123", new DateTime(1972, 3, 1), new DateTime(2020, 4, 1));
            Employee emp6 = new Employee("Sarah Wilson", "2608088661", "6934285123", new DateTime(1991, 3, 1), new DateTime(2020, 4, 1));
            Employee emp7 = new Employee("Christopher Brown", "2708088661", "6984285123", new DateTime(1999, 3, 1), new DateTime(2022, 4, 1));
            Employee emp8 = new Employee("Jennifer Martinez", "2808088661", "6484285123", new DateTime(1990, 3, 1), new DateTime(2021, 4, 1));

            object[,] testcases5 =
            {
                { 1, emp1 , 29 , 14 , msg5 },
                { 2, emp2 , 24 , 9  , msg5 },
                { 3, emp3 , 27 , 14 , msg5 },
                { 4, emp4 , 39 , 12 , msg5 },
                { 5, emp5 , 52 , 4  , msg5 },
                { 6, emp6 , 33 , 4  , msg5 },
                { 7, emp7 , 25 , 2  , msg5 },
                { 8, emp8 , 34 , 3  , msg5 }
            };

            int i = 0;
            bool failed = false;

            for (i = 0; i < testcases5.GetLength(0); i++)
            {
                try
                {
                    int Age = 1;

                    int YearsOfExperience = -1;

                    hr.InfoEmployee((Employee)testcases5[i, 1], ref Age, ref YearsOfExperience);

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

        [TestMethod]
        public void TestMethodLiveInAthens()
        {
            HRLib.HRLib hr = new HRLib.HRLib();

            Employee emp1 = new Employee("JohnSmith", "2108088661", "6984285123", new DateTime(1995, 3, 1), new DateTime(2010, 4, 1));
            Employee emp2 = new Employee("Mary Johnson", "2208088661", "6934285123", new DateTime(2000, 5, 1), new DateTime(2015, 4, 1));
            Employee emp3 = new Employee("David Lee", "2308088661", "6944285123", new DateTime(1997, 6, 1), new DateTime(2010, 4, 1));
            Employee emp4 = new Employee("Emily Chen23@", "2408088661", "6954285123", new DateTime(1985, 3, 1), new DateTime(2012, 4, 1));
            Employee emp5 = new Employee("Michael Davis", "2508088661", "6974285123", new DateTime(1972, 3, 1), new DateTime(2020, 4, 1));
            Employee emp6 = new Employee("Sarah Wilson", "2608088661", "6934285123", new DateTime(1991, 3, 1), new DateTime(2020, 4, 1));
            Employee emp7 = new Employee("Christopher Brown", "2708088661", "6984285123", new DateTime(1999, 3, 1), new DateTime(2022, 4, 1));
            Employee emp8 = new Employee("Jennifer Martinez", "2808088661", "6484285123", new DateTime(1990, 3, 1), new DateTime(2021, 4, 1));

            Employee[] Employees = { emp1, emp2, emp3, emp4, emp5, emp6, emp7, emp8 };

            object[,] testcases6 =
            {
                { 1, Employees , 1 , msg6 }
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
