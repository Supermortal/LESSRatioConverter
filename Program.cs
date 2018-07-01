using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;

namespace LESSRatioConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();

            Console.WriteLine("Input ratio:");
            var ratioText = Console.ReadLine();
            float.TryParse(ratioText, out float ratio);

            Console.WriteLine("Paste the LESS variables:");
            while(true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;

                var numberMatch = (new Regex("\\d+")).Match(line);
                float.TryParse(numberMatch.Value, out float number);
                var newNumber = number * ratio;
                line = line.Replace(numberMatch.Value, newNumber.ToString(CultureInfo.InvariantCulture));
                list.Add(line);
            }

            foreach (var newLine in list)
            {
                Console.WriteLine(newLine);
            }

            Console.Read();
        }
    }
}
