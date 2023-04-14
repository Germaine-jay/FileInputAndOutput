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
                using (StreamReader read = new StreamReader(filepath))
                {
                    string json = read.ReadToEnd();
                    Console.WriteLine(json);
                }
            }

            Console.WriteLine("File does not exist");

        }
    }
}
