using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonAndText.TextReadWrite
{
    public class TextRead
    {
        public static void ReadTextFile()
        {
            string filepath = @"AttributeText.txt";
            foreach (string task in File.ReadAllLines(filepath))
            {
                Console.WriteLine(task);
            }
        }
}
}
