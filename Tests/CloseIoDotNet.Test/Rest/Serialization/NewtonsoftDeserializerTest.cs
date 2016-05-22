namespace CloseIoDotNet.Test.Rest.Serialization
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using CloseIoDotNet.Rest.Serialization;
    using RestSharp;

    [TestClass]
    public class NewtonsoftDeserializerTest
    {
        [TestMethod]
        public void TestDeserialization()
        {
            const string input = @"{
                ""String"": ""value"",
                ""Integer"": 100,
                ""Float"": 200.0,
                ""Decimal"": 300.0,
                ""Date"": ""2000-01-01T00:00:00"",
                ""DateTime"": ""2001-01-01T13:30:45.050Z"",
                ""Array"": [1, 2, 3],
                ""Enumerable"": [""one"", ""two"", ""three""],
                ""InnerObject"": {
                    ""Property"": ""Value""
                }
            }";
            var unit = new NewtonsoftDeserializer();
            var result = unit.Deserialize<MockObject>(new RestResponse() {Content = input});
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(MockObject));
            Assert.IsInstanceOfType(result.InnerObject, typeof(MockInnerObject));

            Assert.AreEqual("value", result.String);
            Assert.AreEqual(100, result.Integer);
            Assert.AreEqual(200f, result.Float);
            Assert.AreEqual(300m, result.Decimal);
            Assert.AreEqual(new DateTime(2000, 1, 1), result.Date);
            Assert.AreEqual(new DateTime(2001, 1, 1, 13, 30, 45).AddMilliseconds(50), result.DateTime);
            Assert.AreEqual(3, result.Array.Length);
            Assert.AreEqual(1, result.Array[0]);
            Assert.AreEqual(2, result.Array[1]);
            Assert.AreEqual(3, result.Array[2]);
            Assert.AreEqual(3, result.Enumerable.Count());
            Assert.IsNotNull(result.Enumerable.Single(entry => string.Equals(entry, "one")));
            Assert.IsNotNull(result.Enumerable.Single(entry => string.Equals(entry, "two")));
            Assert.IsNotNull(result.Enumerable.Single(entry => string.Equals(entry, "three")));
            Assert.IsNotNull(result.InnerObject);
            Assert.AreEqual("Value", result.InnerObject.Property);
        }
    }

    class MockObject
    {
        public string String { get; set; }
        public int Integer { get; set; }
        public double Float { get; set; }
        public decimal Decimal { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateTime { get; set; }
        public int[] Array { get; set; }
        public IEnumerable<string> Enumerable { get; set; }
        public MockInnerObject InnerObject { get; set; }
    }

    class MockInnerObject
    {
        public string Property { get; set; }
    }
}
