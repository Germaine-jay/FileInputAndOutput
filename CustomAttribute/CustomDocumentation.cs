using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute
{
    public class CustomDocumentation
    {
        public static void GetClass(Type type)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("\n");
            Console.WriteLine();
            var types = assembly.GetTypes();

            foreach (Type attrtype in types)
            {
                var attributesz = attrtype.GetCustomAttributes(typeof(DocumentAttribute), true);
                if (attributesz.Length > 0)
                {
                    if (attrtype.IsClass)
                    {
                        Console.WriteLine("Class: {0}", attrtype.Name);
                        Console.WriteLine("\tDescription: {0}", ((DocumentAttribute)attributesz[0]).Description);

                    }

                }
            }

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var AttributesProperty = property.GetCustomAttributes(typeof(DocumentAttribute), true);

                if (AttributesProperty.Length > 0)
                {
                    Console.WriteLine("Property: {0}", property.Name);
                    Console.WriteLine("\tDescription: {0}", ((DocumentAttribute)AttributesProperty[0]).Description);
                    Console.WriteLine("\n");
                }
            }

            ConstructorInfo[] constructorInfo = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructorInfo)
            {
                var constructorAttributes = constructor.GetCustomAttributes(typeof(DocumentAttribute), true);
                if (constructorAttributes.Length > 0)
                {
                    Console.WriteLine("Constructor:\n {0}", constructor.Name);
                    Console.WriteLine("\tDescription: {0}", ((DocumentAttribute)constructorAttributes[0]).Description);
                    Console.WriteLine("\tInput: {0}", ((DocumentAttribute)constructorAttributes[0]).Input);

                    Console.WriteLine("\n");
                }
            }

            /*foreach (Type attrtype in types)
            {
              */  //var attributesz = attrtype.GetCustomAttributes(typeof(DocumentAttribute), true);
                /*if (attributesz.Length > 0)
                {*/
                    if (type.IsEnum)
                    {
                        Console.WriteLine("Enum: {0}", type.Name);
                        Console.WriteLine("\tDescription: {0}", ((DocumentAttribute?)attributesz.SingleOrDefault(x => x.GetType() == typeof(DocumentAttribute)))?.Description);

                        string[] names = type.GetEnumNames();
                        foreach (string name in names)
                        {
                            Console.WriteLine(name);

                        }
                        Console.WriteLine();
                    }
               /* }*/
           /* }*/
        }
    }
    public class RunCustomDocumentation : CustomDocumentation
    {
        public static void GetDocs(Type type)
        {
            GetClass(type);
            /*GetMethods(type);
            GetProperties(type);
            GetConstructorInfo(type);*/

            Console.WriteLine();
        }
    }
}
