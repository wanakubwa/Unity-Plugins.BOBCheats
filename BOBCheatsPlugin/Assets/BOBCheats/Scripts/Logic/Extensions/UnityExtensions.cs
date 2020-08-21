using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BOBCheats.Utils
{
    static class UnityExtensions
    {
        public static string AddSpaces(this string text)
        {
            if (string.IsNullOrWhiteSpace(text) == true)
            {
                return string.Empty;
            }
            
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);

            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) == true && text[i - 1] != ' ')
                {
                    newText.Append(' ');
                }

                newText.Append(text[i]);
            }

            return newText.ToString();
        }

        public static List<Type> GetTypes(this Assembly assembly, Type lookup)
        {
            List<Type> output = new List<Type>();

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass == true && type.IsAbstract == false && type.IsSubclassOf(lookup) == true)
                {
                    output.Add(type);
                }
            }

            return output;
        }

        public static bool HasCustomAttribute(this MethodInfo method, Type attributeType)
        {
            if(method.GetCustomAttributes(attributeType, false).Length > 0)
            {
                return true;
            }

            return false;
        }

        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            if(array == null || array.Length < 1)
            {
                return true;
            }

            return false;
        }

        public static bool IsNullOrEmpty<T>(this List<T> collection)
        {
            if (collection == null || collection.Count < 1)
            {
                return true;
            }

            return false;
        }
    }
}
