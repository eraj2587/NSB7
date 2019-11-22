using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NSB.Utilities.Common
{
    public static class ObjectExt
    {
        public static void ThrowIfNull<T>(this T data, string name) where T : class
        {
            if (data == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void ThrowIfNull<T>(this T data) where T : class
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
        }

        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
