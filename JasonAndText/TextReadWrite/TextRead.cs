namespace JasonAndText.TextReadWrite
{
    public class TextRead
    {
        public static void ReadTextFile()
        {
            Console.WriteLine("Enter file name");
            var Filename = Console.ReadLine();

            string filepath = @$"{Filename}.txt";
            if (!string.IsNullOrEmpty(Filename) && File.Exists(filepath))
            {
                foreach (string task in File.ReadAllLines(filepath))
                {
                    Console.WriteLine(task);
                }
            }

            Console.WriteLine("File does not exist, try again\n");
            ReadTextFile();

        }
    }
}
