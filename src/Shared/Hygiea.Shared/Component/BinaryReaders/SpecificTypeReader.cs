using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    public abstract class SpecificTypeReader<T> : IBinaryReader where T : notnull
    {
        public bool CanRead(Type type)
        {
            return type == typeof(T);
        }

        public object Read(Type type, BinaryReader reader)
        {
            return Read(reader);
        }

        protected abstract T Read(BinaryReader reader);
    }
}
