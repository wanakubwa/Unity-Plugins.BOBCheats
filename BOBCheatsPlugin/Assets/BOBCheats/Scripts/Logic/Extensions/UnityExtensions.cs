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
