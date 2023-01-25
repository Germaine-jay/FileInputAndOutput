using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute
{
    public class CustomDocumentation
    {      
        public static StringBuilder Builder= new StringBuilder();
        public static void GetClass(Type type)
        {

            var assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();

            foreach (Type attrtype in types)
            {
                var attributesz = attrtype.GetCustomAttributes(typeof(DocumentAttribute), true);
                if (attributesz.Length > 0)
                {
                    if (attrtype.IsClass && attrtype == type)
                    {
                        Builder.AppendLine($"Class Name : {attrtype.Name}\n");

                        /*Console.WriteLine("*************************************************************");
                        Console.WriteLine("Class: {0}\n", attrtype.Name);*/
                    }
                }
            }

            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                var AttributesMethods = method.GetCustomAttributes(typeof(DocumentAttribute), true);

                if (AttributesMethods.Length > 0)
                {
                    Builder.AppendLine($"\tMethod Name : {method.Name}");
                    Builder.AppendLine($"\t\tDescription : {(((DocumentAttribute)AttributesMethods[0]).Description)}");
                    Builder.AppendLine($"\t\tInput: {(((DocumentAttribute)AttributesMethods[0]).Input)}\n");

                    /*Console.WriteLine(" -> Method ");
                    Console.WriteLine("\tName: {0}", method.Name);

                    Console.WriteLine("\tDescription: {0}", ((DocumentAttribute)AttributesMethods[0]).Description);
                    Console.WriteLine("\tInput: {0}", ((DocumentAttribute)AttributesMethods[0]).Input);
                    Console.WriteLine("\tOutput: {0}\n", ((DocumentAttribute)AttributesMethods[0]).Output);*/
                }
            }

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var AttributesProperty = property.GetCustomAttributes(typeof(DocumentAttribute), true);

                if (AttributesProperty.Length > 0)
                {
                    Builder.AppendLine($"\tProperty Name : {property.Name}");
                    Builder.AppendLine($"\t\tDescription : {(((DocumentAttribute)AttributesProperty[0]).Description)}");
                    Builder.AppendLine($"\t\tInput : {(((DocumentAttribute)AttributesProperty[0]).Input)}");
                    Builder.AppendLine($"\t\tInput : {(((DocumentAttribute)AttributesProperty[0]).Output)}\n");

                   /* Console.WriteLine("Property: {0}", property.Name);
                    Console.WriteLine("\tDescription: {0}\n", ((DocumentAttribute)AttributesProperty[0]).Description);*/
                }
            }

            ConstructorInfo[] constructorInfo = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructorInfo)
            {
                var constructorAttributes = constructor.GetCustomAttributes(typeof(DocumentAttribute), true);
                if (constructorAttributes.Length > 0)
                {
                    Builder.AppendLine($"\tProperty Name : {constructor.Name}");
                    Builder.AppendLine($"\t\tDescription : {(((DocumentAttribute)constructorAttributes[0]).Description)}");
                    Builder.AppendLine($"\t\tInput: {(((DocumentAttribute)constructorAttributes[0]).Input)}");
                    Builder.AppendLine($"\t\tInput: {(((DocumentAttribute)constructorAttributes[0]).Output)}\n");

                    /*Console.WriteLine("Constructor:\n{0}", constructor.Name);
                    Console.WriteLine("\tDescription: {0}", ((DocumentAttribute)constructorAttributes[0]).Description);
                    Console.WriteLine("\tInput: {0}", ((DocumentAttribute)constructorAttributes[0]).Input);*/

                }
            }

           
            if (type.IsEnum)
            {
                Builder.AppendLine($"\tEnum Name:{type.Name}");
                //Console.WriteLine("Enum: {0}", type.Name);

                string[] names = type.GetEnumNames();
                foreach (string name in names)
                {
                    //Console.WriteLine("\t\t{0}", name);
                    Builder.AppendLine($"\t\t{name}");

                }
                //Console.WriteLine("*************************************************************");
            }
        }
    }
    public class RunCustomDocumentation : CustomDocumentation
    {
        public static void GetDocs(Type type)
        {
            GetClass(type);
        }
    }
}
