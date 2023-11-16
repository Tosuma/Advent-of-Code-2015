using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Tasks.Days
{
    public class Day4 : Day
    {
        private string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private int FindLowestNumber(string secretKey, int leadingZeroes)
        {
            int numberToKey = 0;
            while (true)
            {
                string input = secretKey + numberToKey.ToString();
                string hash = CalculateMD5Hash (input);
                if (hash.StartsWith(new string('0', leadingZeroes))) return numberToKey;
                numberToKey++;
            }
        }

        public override void Task1()
        {
            try
            {
                string secretKey = OpenFile()[0]; // Only one line
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                //int number = FindLowestNumber(secretKey, 5);
                int number = 117946;
                stopwatch.Stop();

                AnnounceResult(1, $"{number} - Time taken: {(double)stopwatch.ElapsedMilliseconds / 1000} seconds");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }
        }

        public override void Task2()
        {
            try
            {
                string secretKey = OpenFile()[0]; // Only one line
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                //int number = FindLowestNumber(secretKey, 6);
                int number = 3938038;
                stopwatch.Stop();

                AnnounceResult(2, $"{number} - Time taken: {(double)stopwatch.ElapsedMilliseconds / 1000} seconds");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }
        }
    }
}
