using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomAttribute;

namespace JasonAndText.TextReadWrite
{
    public class TextWrite
    {
        public static void CreateText()
        {
            using (StreamWriter fs1 = File.CreateText(@"AttributeText.txt"))
                {
                    fs1.WriteLine(CustomDocumentation.Builder);
                }
            Console.WriteLine("Text File Succefully Created");
        }
    }
}
