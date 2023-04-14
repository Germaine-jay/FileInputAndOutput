using System.Data;
using System.Reflection;
using DataStore;


namespace CustomAttribute
{
    public class CustomDocumentation2
    {
        public static Database response = new();
        public static List<Database> responses = new();

        public static void GetClass(Type type)
        {
            var attributesz = type.GetCustomAttributes(typeof(DocumentAttribute), true);
            if (attributesz.Length >0 && attributesz != null)
            {
                if (type.IsClass)
                {
                    response.Name = type.Name;
                }
            }
        }
        public static void GetMethod(Type type)
        {
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                var attrMethod = (DocumentAttribute)method.GetCustomAttribute(typeof(DocumentAttribute));

                if (attrMethod != null)
                {
                    response.Method.Add(new()
                    {
                        Name = method.Name,
                        Description = attrMethod.Description,
                        Input = string.IsNullOrEmpty(attrMethod?.Input) ? string.Empty : attrMethod?.Input,
                        Output = string.IsNullOrEmpty(attrMethod?.Output) ? string.Empty : attrMethod?.Output,
                    });

                }

            }
        }
        public static void GetProperty(Type type)
        {
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var attrProperty = (DocumentAttribute)property.GetCustomAttribute(typeof(DocumentAttribute));

                if (attrProperty != null)
                {
                    response.Properties.Add(new()
                    {
                        Name = property.Name,
                        Description = attrProperty.Description
                    });
                }

            }
        }

        public static void GetConstructor(Type type)
        {
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructorInfo)
            {
                var attrConstructor = (DocumentAttribute)constructor.GetCustomAttribute(typeof(DocumentAttribute));

                if (attrConstructor != null)
                {
                    response.Constructor = new()
                    {
                        Name = constructor.Name,
                        Description = attrConstructor.Description
                    };
                }
            }
        }

        public static void GetEnum(Type type)
        {
            if (type.IsEnum)
            {
                var names = type.GetEnumNames();

                foreach (var name in names)
                {                  
                    var attrenum = (DocumentAttribute)type.GetCustomAttribute(typeof(DocumentAttribute));

                    if (attrenum != null)
                    {
                        response.Enums = new()
                        {
                            Name = type.Name, 
                            Description = attrenum.Description,                    
                        };
                    }
                }
            }
        }
    }
    public class RunCustomDocumentation2 : CustomDocumentation2
    {
        public static void GetDocs()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();

            Type enums = typeof(Scream);

            foreach (Type t in types)
            {
                CustomDocumentation2.GetClass(t);
                CustomDocumentation2.GetMethod(t);
                CustomDocumentation2.GetProperty(t);

                CustomDocumentation2.GetConstructor(t);
                CustomDocumentation2.GetEnum(enums);


                if (!string.IsNullOrEmpty(response.Name))
                {
                    responses.Add(response);
                    response = new();
                }

            }
        }
    }
}
