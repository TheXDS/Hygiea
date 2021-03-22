using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    public class PrimitiveBinaryReader : IBinaryReader
    {
        protected static MethodInfo GetReadMethod(Type t)
        {
            return typeof(BinaryReader).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name.StartsWith("Read") && p.Name != "Read")
                .Where(p => p.ReturnType == t)
                .Where(p => !p.GetParameters().Any())
                .FirstOrDefault();
        }

        public virtual bool CanRead(Type type)
        {
            return type != typeof(string) && GetReadMethod(type) is { };
        }

        public virtual object Read(Type type, BinaryReader reader)
        {
            return (GetReadMethod(type) ?? throw new InvalidOperationException()).Invoke(reader, Type.EmptyTypes);
        }
    }
}
