
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute
{
    public class CustomDocumentation
    {      
        public static StringBuilder Builder = new StringBuilder();
        public static void GetClass(Type type)
        {
            var attributesz = type.GetCustomAttributes(typeof(DocumentAttribute), true);
            if (attributesz.Length > 0)
            {
                if (type.IsClass)
                {
                    Builder.AppendLine($"Class Name : {type.Name}\n");
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
                }
            }
        
            if (type.IsEnum)
            {
                Builder.AppendLine($"\tEnum Name:{type.Name}");
                string[] names = type.GetEnumNames();
                foreach (string name in names)
                {
                    Builder.AppendLine($"\t\t{name}");
                }
            }
        }
    }
    public class RunCustomDocumentation
    {
        public static void GetDocs()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();

            foreach (Type t in types)
            {
                CustomDocumentation.GetClass(t);
            }
        }
    }
}
