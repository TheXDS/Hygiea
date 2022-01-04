using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using System.Text;

namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Describes a registry value.
    /// </summary>
    public class RegistryKeyValueManifest
    {
        /// <summary>
        /// Gets the name of this value.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets the kind of value stored.
        /// </summary>
        public RegistryValueKind Kind { get; set; }

        /// <summary>
        /// Gets a blob of raw data that represents the actual value.
        /// </summary>
        public byte[] RawData { get; set; } = null!;

        /// <summary>
        /// Converts the raw blob of data into an object.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if <see cref="Kind"/> is equal to 
        /// <see cref="RegistryValueKind.None"/> or a non-defined value for the
        /// <see cref="RegistryValueKind"/> enumeration.
        /// </exception>
        public object? GetValue()
        {
            return Kind switch
            {
                RegistryValueKind.String => Encoding.UTF8.GetString(RawData),
                RegistryValueKind.ExpandString => Encoding.UTF8.GetString(RawData),
                RegistryValueKind.Binary => RawData,
                RegistryValueKind.DWord => BitConverter.ToInt32(RawData, 0),
                RegistryValueKind.MultiString => ReadStrings(RawData),
                RegistryValueKind.QWord => BitConverter.ToInt64(RawData, 0),
                RegistryValueKind.None => null,
                RegistryValueKind.Unknown => RawData,
                _ => throw new InvalidOperationException(),
            };
        }

        private static string[] ReadStrings(byte[] rawData)
        {
            using MemoryStream ms = new MemoryStream(rawData);
            using BinaryReader br = new BinaryReader(ms);
            var l = new List<string>();
            var c = br.ReadInt32();
            while (c-- > 0)
            {
                l.Add(br.ReadString());
            }
            return l.ToArray();
        }
    }
}
