using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager.DAL.Entities;
using PasswordManager.DAL.Entities.Attributes;
using PasswordManager.DAL.Repositories;
using System;
using System.Linq;

namespace PasswordManager.Tests
{
    [TestClass]
    public class PropertiesDbProviderTests
    {
        [TestMethod]
        public void GetProperties_NoPropertiesWithDbAttributeNameAttribute_ReturnEmptyCollection()
        {
            // arrange
            IEntity entry = new WithoutDbAttributeNameAttribute();
            PropertiesDbProvider provider = new PropertiesDbProvider();

            // act
            var result = provider.GetProperties(entry);

            // assert
            Assert.AreEqual(0, result.Count());
        }

        private string GetProperties(IEntity entity)
        {
            return null;
        }

        [TestMethod]
        public void GetProperties_EntityDoesNotContainsDbTableNameAttrubute_ThrowArgumentException()
        {
            // arrange
            IEntity entity = new WithoutDbTableNameAttribute();
            PropertiesDbProvider provider = new PropertiesDbProvider();

            // act
            ArgumentException result = Assert.ThrowsException<ArgumentException>(() => provider.GetProperties(entity));

            // assert
            Assert.AreEqual(typeof(ArgumentException), result.GetType());
        }



        [TestMethod]
        public void CheckDbTableNameAttrubute_ContainsAttribute_ReturnTrue()
        {
            // arrange
            IEntity entity = new DbEntry();
            PropertiesDbProvider provider = new PropertiesDbProvider();

            // act
            bool result = provider.CheckDbTableNameAttribute(entity);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckTableNameAttribute_NoAttribute_ReturnFalse()
        {
            // arrange
            IEntity entity = new WithoutDbTableNameAttribute();
            PropertiesDbProvider provider = new PropertiesDbProvider();

            // act
            bool result = provider.CheckDbTableNameAttribute(entity);

            // assert
            Assert.IsFalse(result);
        }
    }

    public class WithoutDbTableNameAttribute : IEntity
    {
        public int Id { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
    [DbTableName("")]
    public class WithoutDbAttributeNameAttribute : IEntity
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
