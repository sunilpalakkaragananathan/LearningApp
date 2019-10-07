using System;
using System.Text.RegularExpressions;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            const string YOUR_STRING = "0009123";
            //var regexItem = new Regex("^[0-9]*$");
           
            if (Regex.IsMatch("00438967", @"^[0-9]{1}[1-9]+$"))
                Console.WriteLine();
        }
    }
}
