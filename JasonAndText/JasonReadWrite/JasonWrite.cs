
using CustomAttribute;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JasonAndText.JasonReadWrite
{

    public class JasonWrite
    {
        private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
        public static void WriteJasonfile()
        {
            Console.WriteLine("Enter file name");
            var CreateFile = Console.ReadLine();

            if (!string.IsNullOrEmpty(CreateFile))
            {
                var fileName = @$"{CreateFile}.json";
                if (File.Exists(fileName)) File.Delete(fileName);

                var options = new JsonSerializerOptions(_options) { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(CustomDocumentation2.responses, options);

                File.WriteAllText(fileName, jsonString);
                Console.WriteLine("Json file created successfully");
            }

            Console.WriteLine(" File name cannot be empty");
            WriteJasonfile();

        }
    }


}
