using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JasonAndText.JasonReadWrite
{
    public class JasonRead
    {
        public static void ReadJasonfile()
        {
            Console.WriteLine("Enter file name");
            var Filename = Console.ReadLine();

            string filepath = @$"{Filename}.json";
            if (!string.IsNullOrEmpty(Filename) && File.Exists(filepath))
            {
                using (StreamReader r = new StreamReader(filepath))
                {
                    string json = r.ReadToEnd();
                    Console.WriteLine(json);
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
    }
}
