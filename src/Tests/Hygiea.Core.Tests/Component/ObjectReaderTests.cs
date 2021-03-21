#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TheXDS.Hygiea.Component;
using TheXDS.Hygiea.Component.BinaryReaders;
using Xunit;

namespace TheXDS.Hygiea.Core.Tests.Component
{
    public class ObjectReaderTests
    {
        public static IEnumerable<object[]> TypedDataTestProvider()
        {
            yield return new object[] { 1000000, BitConverter.GetBytes(1000000) };
            yield return new object[] { true, BitConverter.GetBytes(true) };
            yield return new object[] { 100200300L, BitConverter.GetBytes(100200300L) };
            yield return new object[] { TestEnum.Two, BitConverter.GetBytes((short)TestEnum.Two) };
            yield return new object[] { Math.PI, BitConverter.GetBytes(Math.PI) };
            yield return new object[] { float.Epsilon, BitConverter.GetBytes(float.Epsilon) };
            yield return new object[] { double.NaN, BitConverter.GetBytes(double.NaN) };
            yield return new object[] { double.PositiveInfinity, BitConverter.GetBytes(double.PositiveInfinity) };
            yield return new object[] { double.NegativeInfinity, BitConverter.GetBytes(double.NegativeInfinity) };
            yield return new object[] { 12.5M, decimal.GetBits(12.5M).SelectMany(BitConverter.GetBytes).ToArray() };

            var g = Guid.NewGuid();
            yield return new object[] { g, g.ToByteArray() };

            var d = DateTime.Now;
            yield return new object[] { d, BitConverter.GetBytes(d.ToBinary()) };
        }

        private class TestDataClass
        {
            public int Int32Value { get; set; }
            public string StringValue { get; set; }
            public Guid GuidValue { get; set; }
            public DateTime DateTimeValue { get; set; }
            public TestEnum EnumValue { get; set; }
            public TestDataClass ObjectValue { get; set; }
            public int[] Int32Array { get; set; }
            public string[] StringArray { get; set; }
            public Guid[] GuidArray { get; set; }
            public DateTime[] DateTimeArray { get; set; }
            public TestEnum[] EnumArray { get; set; }
            public TestDataClass[] ObjectArray { get; set; }
        }

        private enum TestEnum : short
        {
            Zero, One, Two
        }

        [Fact]
        public void ObjectReaderParsesObject_Test()
        {
            var g = Guid.NewGuid();
            var t = DateTime.Now;

            using var ms = new MemoryStream();
            using (var bw = new BinaryWriter(ms, Encoding.UTF8, true))
            {
                // TestDataClass
                bw.Write((byte)ObjectType.Instance);
                bw.Write((byte)0);
                bw.Write(1);
                bw.Write("Test");
                bw.Write(g.ToByteArray());
                bw.Write(t.ToBinary());
                bw.Write((short)TestEnum.One);

                // TestDataClass.ObjectValue
                bw.Write((byte)ObjectType.Instance);
                bw.Write((byte)0);
                bw.Write(10);
                bw.Write("Test10");
                bw.Write(g.ToByteArray());
                bw.Write(t.ToBinary());
                bw.Write((short)TestEnum.Two);
                bw.Write((byte)ObjectType.Null);
                bw.Write(0);
                bw.Write(-1);
                bw.Write(-1);
                bw.Write(-1);
                bw.Write(-1);
                bw.Write(-1);

                // int[]
                bw.Write(3);
                bw.Write(1);
                bw.Write(2);
                bw.Write(3);

                // string[]
                bw.Write(3);
                bw.Write("Test1");
                bw.Write("Test2");
                bw.Write("Test3");

                // Guid[]
                bw.Write(3);
                bw.Write(g.ToByteArray());
                bw.Write(g.ToByteArray());
                bw.Write(g.ToByteArray());

                // DateTime[]
                bw.Write(3);
                bw.Write(t.ToBinary());
                bw.Write(t.ToBinary());
                bw.Write(t.ToBinary());

                // Enum[]
                bw.Write(3);
                bw.Write((short)TestEnum.Zero);
                bw.Write((short)TestEnum.One);
                bw.Write((short)TestEnum.Two);

                // TestDataClass[]
                bw.Write(2);
                // 1
                bw.Write((byte)ObjectType.Null);
                //2
                bw.Write((byte)ObjectType.Instance);
                bw.Write((byte)0);
                bw.Write(2);
                bw.Write("Test2");
                bw.Write(g.ToByteArray());
                bw.Write(t.ToBinary());
                bw.Write((short)TestEnum.Two);
                bw.Write((byte)ObjectType.Null);
                bw.Write(3);
                bw.Write(1);
                bw.Write(2);
                bw.Write(3);
                bw.Write(-1);
                bw.Write(0);
                bw.Write(-1);
                bw.Write(-1);
                bw.Write(-1);
            }
            ms.Position = 0;

            var m = Assert.IsType<TestDataClass>(ObjectReader.Read<TestDataClass>(ms));

            Assert.Equal(1, m.Int32Value);
            Assert.Equal("Test", m.StringValue);
            Assert.Equal(g, m.GuidValue);
            Assert.Equal(t, m.DateTimeValue);
            Assert.Equal(TestEnum.One, m.EnumValue);
            Assert.Equal(10, m.ObjectValue.Int32Value);
            Assert.Equal("Test10", m.ObjectValue.StringValue);
            Assert.Equal(g, m.ObjectValue.GuidValue);
            Assert.Equal(t, m.ObjectValue.DateTimeValue);
            Assert.Equal(TestEnum.Two, m.ObjectValue.EnumValue);
            Assert.Null(m.ObjectValue.ObjectValue);
            Assert.Equal(Array.Empty<int>(), m.ObjectValue.Int32Array);
            Assert.Null(m.ObjectValue.StringArray);
            Assert.Null(m.ObjectValue.GuidArray);
            Assert.Null(m.ObjectValue.DateTimeArray);
            Assert.Null(m.ObjectValue.EnumArray);
            Assert.Null(m.ObjectValue.ObjectArray);
            Assert.Equal(new[] { 1, 2, 3 }, m.Int32Array);
            Assert.Equal(new[] { "Test1", "Test2", "Test3" }, m.StringArray);
            Assert.Equal(new[] { g, g, g }, m.GuidArray);
            Assert.Equal(new[] { t, t, t }, m.DateTimeArray);
            Assert.Equal(new[] { TestEnum.Zero, TestEnum.One, TestEnum.Two }, m.EnumArray);
            Assert.Equal(2, m.ObjectArray.Length);
            Assert.Null(m.ObjectArray[0]);
            Assert.Equal(2, m.ObjectArray[1].Int32Value);
            Assert.Equal("Test2", m.ObjectArray[1].StringValue);
            Assert.Equal(g, m.ObjectArray[1].GuidValue);
            Assert.Equal(t, m.ObjectArray[1].DateTimeValue);
            Assert.Equal(TestEnum.Two, m.ObjectArray[1].EnumValue);
            Assert.Null(m.ObjectArray[1].ObjectValue);
            Assert.Equal(new[] { 1, 2, 3 }, m.ObjectArray[1].Int32Array);
            Assert.Null(m.ObjectArray[1].StringArray);
            Assert.Equal(Array.Empty<Guid>(), m.ObjectArray[1].GuidArray);
            Assert.Null(m.ObjectArray[1].DateTimeArray);
            Assert.Null(m.ObjectArray[1].EnumArray);
            Assert.Null(m.ObjectArray[1].ObjectArray);
        }

        [Fact]
        public void ObjectReaderParsesArray_Test()
        {
            using (var ms = new MemoryStream(new byte[]
            {
                3, 0, 0, 0,
                1, 0, 0, 0,
                2, 0, 0, 0,
                3, 0, 0, 0
            }))
            {
                Assert.Equal(new int[] { 1, 2, 3 }, ObjectReader.Read<int[]>(ms));
            }
            using (var ms = new MemoryStream(new byte[] { 0, 0, 0, 0 }))
            {
                Assert.Equal(Array.Empty<int>(), ObjectReader.Read<int[]>(ms));
            }
            using (var ms = new MemoryStream(new byte[] { 255, 255, 255, 255 }))
            {
                Assert.Null(ObjectReader.Read<int[]>(ms));
            }
        }

        [Fact]
        public void ObjectReaderParsesNullableStructs_Test()
        {
            using (var ms = new MemoryStream(new byte[] { (byte)ObjectType.Instance, 5, 0, 0, 0 }))
            {
                var v = ObjectReader.Read<int?>(ms);
                Assert.NotNull(v);
                Assert.Equal(5, v!.Value);
            }
            using (var ms = new MemoryStream(new byte[] { (byte)ObjectType.Default }))
            {
                var v = ObjectReader.Read<int?>(ms);
                Assert.NotNull(v);
                Assert.Equal(0, v!.Value);
            }
            using (var ms = new MemoryStream(new byte[] { (byte)ObjectType.Null }))
            {
                Assert.Null(ObjectReader.Read<int?>(ms));
            }
        }

        [Theory]
        [MemberData(nameof(TypedDataTestProvider))]
        public void ObjectReaderParsesData_Test(object obj, byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            using var br = new BinaryReader(ms);
            Assert.Equal(obj, ObjectReader.Read(obj.GetType(), br));
        }
    }
}
