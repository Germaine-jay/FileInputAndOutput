namespace DataStore
{
    public class Database
    {   
        public Database()
        {
            Method =  new ();
            Properties = new ();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Props Constructor { get; set; }
        public List<Props> Properties { get; set; }
        public List<MethodProps> Method { get; set; }
        public Enusprops Enums { get; set; }

    }

    public class Props
    {
        public string? Name { get; set;}
        public string? Description { get; set;}
    }

    public class MethodProps : Props
    {
        public string? Input { get; set; }
        public string? Output { get; set; }
    }

    public class Enusprops : Props
    {
        public string[] Input { get; set; }
    }
}
