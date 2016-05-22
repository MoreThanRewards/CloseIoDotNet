namespace CloseIoDotNet.Test.Rest.Serialization
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using CloseIoDotNet.Rest.Serialization;

    [TestClass]
    public class NewtonsoftSerializerTest
    {
        [TestMethod]
        public void TestSerialization()
        {
            var unit = new NewtonsoftSerializer();
            var input = new 
            {
                String = "test",
                Int = 100,
                Float = 200f,
                Decimal = 300m,
                Date = new DateTime(2000, 1, 1).Date,
                DateTime = new DateTime(2001, 1, 1, 13, 45, 1),
                Array = new [] {1, 2, 3},
                Enumerable = new List<string>() { "1", "2", "3" },
                InnerObject = new {
                    unit = "test"
                }
            };
            var result = unit.Serialize(input);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual("application/json", unit.ContentType);

            Assert.IsTrue(Regex.IsMatch(result, "{*}"));
            Assert.IsTrue(result.Contains("\"String\":\"test\""));
            Assert.IsTrue(result.Contains("\"Int\":100"));
            Assert.IsTrue(result.Contains("\"Float\":200.0"));
            Assert.IsTrue(result.Contains("\"Decimal\":300.0"));
            Assert.IsTrue(result.Contains("\"Date\":\"2000-01-01T00:00:00\""));
            Assert.IsTrue(result.Contains("\"DateTime\":\"2001-01-01T13:45:01\""));
            Assert.IsTrue(result.Contains("\"Array\":[1,2,3]"));
            Assert.IsTrue(result.Contains("\"Enumerable\":[\"1\",\"2\",\"3\"]"));
            Assert.IsTrue(result.Contains("\"InnerObject\":{\"unit\":\"test\"}"));

        }
    }
}
