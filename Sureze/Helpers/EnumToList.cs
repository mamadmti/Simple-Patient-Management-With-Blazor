using System.ComponentModel;
using System.Text.RegularExpressions;
using static Sureze.Domain.Entities.Enums.PatientsEnums;

namespace Sureze.Helpers
{
    public static class Extension
    {
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }


        public static string Rmchar(this string Inputstr)
        {
            //string str = Regex.Replace(Inputstr, @"[\[\]\n\r \']+", string.Empty);
            if (Inputstr != null)
            {
                Inputstr = Inputstr.Trim(' ', '\t', '\n', '\v', '\f', '\r', '"', ']', '[', '!');
                return Regex.Replace(Inputstr, @"\s+", "");
            }
            else
            {
                return null;
            }
            //return str;
        }
        public static string Rmcharwithspaces(this string Inputstr)
        {
            //string str = Regex.Replace(Inputstr, @"[\[\]\n\r \']+", string.Empty);
            if (Inputstr != null)
            {
                return Inputstr = Inputstr.Trim(' ', '\t', '\n', '\v', '\f', '\r', '"', ']', '[', '!');
            }
            else
            {
                return null;
            }
            //return str;
        }
        public static string OnlyNumbersAndDots(this string Inputstr)
        {
            if (Inputstr != null)
            {
                var allowedChars = "01234567890.";
                return new string(Inputstr.Where(c => allowedChars.Contains(c)).ToArray());
            }
            else
            {
                return null;
            }
            //Inputstr = Inputstr.Trim(' ', '\t', '\n', '\v', '\f', '\r', '"', ']', '[', '!');
            //return Regex.Replace(Inputstr, @"\D+", "");

        }
        public static string OnlyNumbers(this string Inputstr)
        {
            if (Inputstr != null)
            {
                var allowedChars = "01234567890";
                return new string(Inputstr.Where(c => allowedChars.Contains(c)).ToArray());
            }
            else
            {
                return null;
            }
            //Inputstr = Inputstr.Trim(' ', '\t', '\n', '\v', '\f', '\r', '"', ']', '[', '!');
            //return Regex.Replace(Inputstr, @"\D+", "");

        }
        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }


        public static string RmDualPrice(this string Inputstr)
        {
            if (Inputstr != null)
            {
                var allowedChars = "01234567890.";
                Inputstr = Inputstr.Substring(Inputstr.IndexOf('≈') + 1);
                string x = new string(Inputstr.Where(c => allowedChars.Contains(c)).ToArray());
                return x;

            }
            else
            {
                return null;
            }
        }

        

    }
}
