using JasonAndText.JasonReadWrite;
using JasonAndText.TextReadWrite;

namespace FileInputAndOutput
{
    public class LandingPage
    {
        public static void StartApp()
        {

            bool Validate = true;
            while (Validate)
            {
                Console.WriteLine("Enter: \n 1 -> Create Text file\n 2 -> Read Text file\n 3 -> Create Jason File\n 4 -> Read Jason File");
                var Option = Console.ReadLine();
                Console.WriteLine();

                switch (Option)
                {
                    case "1":
                        Console.Clear();
                        TextWrite.CreateText();
                        break;

                    case "2":
                        Console.Clear();
                        TextRead.ReadTextFile();
                        break;

                    case "3":
                        Console.Clear();
                        JasonWrite.WriteJasonfile();
                        break;

                    case "4":
                        Console.Clear();
                        JasonRead.ReadJasonfile();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Option");
                        StartApp();
                        break;
                }

                Console.Write("\n\t Do you want to carry out another operation? (y/n) \n\t ");

                string repeatChoice = Console.ReadLine().ToLower();

                if (repeatChoice == "n" || repeatChoice != "y")
                {
                    Validate = false;
                }
                else if (repeatChoice == "y")
                {
                    Validate = true;
                    Console.Clear();
                    StartApp();
                }
            }
        }
    }
}
