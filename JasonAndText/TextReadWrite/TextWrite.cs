using CustomAttribute;

namespace JasonAndText.TextReadWrite
{
    public class TextWrite
    {
        public static void CreateText()
        {
            Console.WriteLine("Enter file name");
            var Filename = Console.ReadLine();

            if (!string.IsNullOrEmpty(Filename))
            {
                string filepath = @$"{Filename}.txt";

                if (File.Exists(filepath)) File.Delete(filepath);

                using (StreamWriter fs1 = File.CreateText(filepath))
                {
                    fs1.WriteLine(CustomDocumentation.Builder);
                }
            }
            else
            {
                Console.WriteLine(" File name cannot be empty");
                CreateText();
            }

        }
    }
}
