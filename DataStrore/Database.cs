using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using CustomAttribute;

namespace DataStore
{
    public class Database
    {
        public Database() { }
        public Database(string className, IEnumerable<string> constructor, IEnumerable<Props> method, IEnumerable<string> properties, string[] enums)
        {
            ClassName = className;
            Method = method != null ? new List<Props>((IEnumerable<Props>)method) : new List<Props>();
            Properties = properties != null ? new List<Props>((IEnumerable<Props>)properties) : new List<Props>();
            Constructor = constructor != null ? new List<Props>((IEnumerable<Props>)constructor) : new List<Props>();
            //Enums = enums;
        }
        public string? ClassName { get; set; }
        public IEnumerable<Props>? Method { get; set; }
        public IEnumerable<Props>? Constructor { get; set; }
        public IEnumerable<Props>? Properties { get; set; }
        //public static string[]? Enums { get; set; }
        public ArrayList? Enums { get; set; }

    }

    public class UseDoc: CustomDocumentation
    {
        public static void Run()
        {
            
            var Data = new Database
            {
                ClassName = "Bezao",

                Method = new List<Props>
                {
                    new Props { Name = "Me", Description = "Baddest", Input = "input", Output = null },
                    new Props { Name = "Me", Description = "Baddest", Input = "input", Output = null },

                },
                Enums = new ArrayList() { "", "Windy", "Humid" }
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Data, options);
            Console.WriteLine(jsonString);
        }
    }

    public class Props
    {
        public string? Name { get; set;}
        public string? Description { get; set;}
        public string? Input { get; set;}
        public string? Output { get; set;}
    }
}
