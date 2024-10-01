using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRLib
{
    public class HRLib
    {
        public struct Employee
        {
            public string Name;
            public string HomePhone;
            public string MobilePhone;
            public DateTime Birthday;
            public DateTime HiringDate;

            public Employee(string N, string HP, string MP, DateTime B, DateTime H)
            {
                Name = N;
                HomePhone = HP;
                MobilePhone = MP;
                Birthday = B;
                HiringDate = H;
            }
        }

        public bool ValidName(string Name)
        {
            if (!Regex.IsMatch(Name, "^[a-zA-Z]+[ \t][a-zA-Z]+$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidPassword(string password)
        {
            if (password.Length <= 12) // Επίτηδες Λάθος <=, Σωστό <
                return false;

            if (!Regex.IsMatch(password, "[A-Z]") ||
                !Regex.IsMatch(password, "[a-z]") ||
                !Regex.IsMatch(password, @"\d") ||
                !Regex.IsMatch(password, @"[!@#$%^&*()-+=]"))
                return false;

            foreach (char c in password)
            {
                if (c < 32 || c > 126)
                    return false;
            }

            if (!char.IsUpper(password[0]) || !char.IsDigit(password[password.Length - 1]))
                return false;

            return true;
        }

        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }

        public void ΕncryptPassword(string Password, ref string ΕncryptedPW)
        {
            ΕncryptedPW = string.Empty;

            foreach (char ch in Password)
                ΕncryptedPW += cipher(ch, 5);

        }

        public void CheckPhone(string Phone, ref int TypePhone, ref string InfoPhone)
        {
            if (Phone.Length == 10)
            {
                if (Phone.StartsWith("2"))
                {
                    TypePhone = 0;

                    if (Phone.StartsWith("21"))
                    {
                        InfoPhone = "21";
                    }
                    else if (Phone.StartsWith("22"))
                    {
                        InfoPhone = "22";
                    }
                    else if (Phone.StartsWith("23"))
                    {
                        InfoPhone = "23";
                    }
                    else if (Phone.StartsWith("24"))
                    {
                        InfoPhone = "24";
                    }
                    else if (Phone.StartsWith("25"))
                    {
                        InfoPhone = "25";
                    }
                    else if (Phone.StartsWith("26"))
                    {
                        InfoPhone = "26";
                    }
                    else if (Phone.StartsWith("27"))
                    {
                        InfoPhone = "27";
                    }
                    else if (Phone.StartsWith("28"))
                    {
                        InfoPhone = "28";
                    }
                    else
                    {
                        InfoPhone = null;
                    }

                }
                else if (Phone.StartsWith("69"))
                {
                    TypePhone = 1;

                    if (Phone.StartsWith("697") || Phone.StartsWith("698"))
                    {
                        InfoPhone = "Cosmote";
                    }
                    else if (Phone.StartsWith("694") || Phone.StartsWith("695"))
                    {
                        InfoPhone = "Vodaphone"; //Επίτηδες Λάθος, Σωστό "Vodafone"
                    }
                    else if (Phone.StartsWith("693"))
                    {
                        InfoPhone = "Nova";
                    }
                    else
                    {
                        InfoPhone = null;
                    }
                }
                else
                {
                    TypePhone = -1;
                    // Επίτηδες Λάθος, Σωστό InfoPhone = null;
                }

            }

        }

        public void InfoEmployee(Employee EmplX, ref int Age, ref int YearsOfExperience)
        {
            Age = DateTime.Now.Year - EmplX.Birthday.Year;
            YearsOfExperience = DateTime.Now.Year - EmplX.HiringDate.Year;

        }

        public int LiveInAthens(Employee[] Empls)
        {
            string IPh = "0";
            int TPh = 0;
            int Count = 0;

            foreach (Employee x in Empls)
            {
                CheckPhone(x.MobilePhone, ref TPh, ref IPh); // Επίτηδες Λάθος, Σωστό CheckPhone(x.HomePhone, ref TPh, ref IPh);
                if (IPh == "21")
                {
                    Count++;
                }
            }

            return Count;
        }
    }
}