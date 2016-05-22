namespace CloseIoDotNet.Test.Entities.Fields
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Definitions.Opportunities;
    using CloseIoDotNet.Entities.Fields;

    [TestClass]
    public class BaseEntityFieldTest
    {
        [TestMethod]
        public void TestBelongsToIsTypeT()
        {
            var unitLead = new BaseEntityField<Lead>();
            Assert.AreEqual(typeof(Lead), unitLead.BelongsTo);

            var unitOpportunity = new BaseEntityField<Opportunity>();
            Assert.AreEqual(typeof(Opportunity), unitOpportunity.BelongsTo);
        }

        [TestMethod]
        public void TestNameGetterThrowsInvalidOperationExceptionIfNull()
        {
            try
            {
                var unit = new BaseEntityField<Lead>()
                {
                    SerializedName = "unit test",
                    IsRequiredOnCreate = false,
                    IsRequiredOnDelete = false,
                    IsAllowedOnUpdate = false,
                    IsAllowedOnCreate = false,
                    IsRequiredOnUpdate = false
                };
                var fail = unit.Name;
                Assert.Fail("Expected InvalidOperationException not thrown.");
            }
            catch (InvalidOperationException)
            {
                //expected
            }

            var unitPass = new BaseEntityField<Lead>()
            {
                Name = "unit test",
                SerializedName = "unit test",
                IsRequiredOnCreate = false,
                IsRequiredOnDelete = false,
                IsAllowedOnUpdate = false,
                IsAllowedOnCreate = false,
                IsRequiredOnUpdate = false
            };
            var succeed = unitPass.Name;
        }

        [TestMethod]
        public void TestSerializedNameGetterThrowsInvalidOperationExceptionIfNull()
        {
            try
            {
                var unit = new BaseEntityField<Lead>()
                {
                    Name = "unit test",
                    IsRequiredOnCreate = false,
                    IsRequiredOnDelete = false,
                    IsAllowedOnUpdate = false,
                    IsAllowedOnCreate = false,
                    IsRequiredOnUpdate = false
                };
                var fail = unit.SerializedName;
                Assert.Fail("Expected InvalidOperationException not thrown.");
            }
            catch (InvalidOperationException)
            {
                //expected
            }

            var unitPass = new BaseEntityField<Lead>()
            {
                Name = "unit test",
                SerializedName = "unit test",
                IsRequiredOnCreate = false,
                IsRequiredOnDelete = false,
                IsAllowedOnUpdate = false,
                IsAllowedOnCreate = false,
                IsRequiredOnUpdate = false
            };
            var succeed = unitPass.SerializedName;
        }

        [TestMethod]
        public void TestIsRequiredOnCreateGetterThrowsInvalidOperationExceptionIfNull()
        {
            try
            {
                var unit = new BaseEntityField<Lead>()
                {
                    Name = "unit test",
                    SerializedName = "unit test",
                    //IsRequiredOnCreate = false,
                    IsRequiredOnDelete = false,
                    IsAllowedOnUpdate = false,
                    IsAllowedOnCreate = false,
                    IsRequiredOnUpdate = false
                };
                var fail = unit.IsRequiredOnCreate;
                Assert.Fail("Expected InvalidOperationException not thrown.");
            }
            catch (InvalidOperationException)
            {
                //expected
            }

            var unitPass = new BaseEntityField<Lead>()
            {
                Name = "unit test",
                SerializedName = "unit test",
                IsRequiredOnCreate = false,
                IsRequiredOnDelete = false,
                IsAllowedOnUpdate = false,
                IsAllowedOnCreate = false,
                IsRequiredOnUpdate = false
            };
            var succeed = unitPass.IsRequiredOnCreate;
        }

        [TestMethod]
        public void TestIsAllowedOnCreateGetterThrowsInvalidOperationExceptionIfNull()
        {
            try
            {
                var unit = new BaseEntityField<Lead>()
                {
                    Name = "unit test",
                    SerializedName = "unit test",
                    IsRequiredOnCreate = false,
                    IsRequiredOnDelete = false,
                    IsAllowedOnUpdate = false,
                    //IsAllowedOnCreate = false,
                    IsRequiredOnUpdate = false
                };
                var fail = unit.IsAllowedOnCreate;
                Assert.Fail("Expected InvalidOperationException not thrown.");
            }
            catch (InvalidOperationException)
            {
                //expected
            }

            var unitPass = new BaseEntityField<Lead>()
            {
                Name = "unit test",
                SerializedName = "unit test",
                IsRequiredOnCreate = false,
                IsRequiredOnDelete = false,
                IsAllowedOnUpdate = false,
                IsAllowedOnCreate = false,
                IsRequiredOnUpdate = false
            };
            var succeed = unitPass.IsAllowedOnCreate;
        }

        [TestMethod]
        public void TestIsRequiredOnUpdateGetterThrowsInvalidOperationExceptionIfNull()
        {
            try
            {
                var unit = new BaseEntityField<Lead>()
                {
                    Name = "unit test",
                    SerializedName = "unit test",
                    IsRequiredOnCreate = false,
                    IsRequiredOnDelete = false,
                    IsAllowedOnUpdate = false,
                    IsAllowedOnCreate = false,
                    //IsRequiredOnUpdate = false
                };
                var fail = unit.IsRequiredOnUpdate;
                Assert.Fail("Expected InvalidOperationException not thrown.");
            }
            catch (InvalidOperationException)
            {
                //expected
            }

            var unitPass = new BaseEntityField<Lead>()
            {
                Name = "unit test",
                SerializedName = "unit test",
                IsRequiredOnCreate = false,
                IsRequiredOnDelete = false,
                IsAllowedOnUpdate = false,
                IsAllowedOnCreate = false,
                IsRequiredOnUpdate = false
            };
            var succeed = unitPass.IsRequiredOnUpdate;
        }

        [TestMethod]
        public void TestIsAllowedOnUpdateGetterThrowsInvalidOperationExceptionIfNull()
        {
            try
            {
                var unit = new BaseEntityField<Lead>()
                {
                    Name = "unit test",
                    SerializedName = "unit test",
                    IsRequiredOnCreate = false,
                    IsRequiredOnDelete = false,
                    //IsAllowedOnUpdate = false,
                    IsAllowedOnCreate = false,
                    IsRequiredOnUpdate = false
                };
                var fail = unit.IsAllowedOnUpdate;
                Assert.Fail("Expected InvalidOperationException not thrown.");
            }
            catch (InvalidOperationException)
            {
                //expected
            }

            var unitPass = new BaseEntityField<Lead>()
            {
                Name = "unit test",
                SerializedName = "unit test",
                IsRequiredOnCreate = false,
                IsRequiredOnDelete = false,
                IsAllowedOnUpdate = false,
                IsAllowedOnCreate = false,
                IsRequiredOnUpdate = false
            };
            var succeed = unitPass.IsAllowedOnUpdate;
        }

        [TestMethod]
        public void TestIsRequiredOnDeleteGetterThrowsInvalidOperationExceptionIfNull()
        {
            try
            {
                var unit = new BaseEntityField<Lead>()
                {
                    Name = "unit test",
                    SerializedName = "unit test",
                    IsRequiredOnCreate = false,
                    //IsRequiredOnDelete = false,
                    IsAllowedOnUpdate = false,
                    IsAllowedOnCreate = false,
                    IsRequiredOnUpdate = false
                };
                var fail = unit.IsRequiredOnDelete;
                Assert.Fail("Expected InvalidOperationException not thrown.");
            }
            catch (InvalidOperationException)
            {
                //expected
            }

            var unitPass = new BaseEntityField<Lead>()
            {
                Name = "unit test",
                SerializedName = "unit test",
                IsRequiredOnCreate = false,
                IsRequiredOnDelete = false,
                IsAllowedOnUpdate = false,
                IsAllowedOnCreate = false,
                IsRequiredOnUpdate = false
            };
            var succeed = unitPass.IsRequiredOnDelete;
        }
    }
}
