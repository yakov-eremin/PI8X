using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager.DAL.Entities;
using PasswordManager.DAL.Entities.Attributes;
using PasswordManager.DAL.Repositories;
using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void GetProperties_EntityContainsNesessaryProperties_ReturnNotEmptyCollection()
        {
            // arrange
            IEntity entry = new DbEntry();
            PropertiesDbProvider provider = new PropertiesDbProvider();

            // act
            var result = provider.GetProperties(entry);

            // assert
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod]
        public void GetProperties_AllDbEntities_ReturnEqualPropertiesCollectionForEachEntity()
        {
            // arrange
            PropertiesDbProvider provider = new PropertiesDbProvider();
            List<IEntity> entities = new List<IEntity>()
            {
                new DbAccessWay(),
                new DbEntry(),
                new DbGroup(),
                new PasswordDb(),
                new EncryptionAlgorithm(),
            };
            // act
            List<ICollection<string>> collections = new List<ICollection<string>>();
            foreach (var item in entities)
            {
                collections.Add(provider.GetProperties(item));
            }

            // assert
            for (int i = 0; i < entities.Count; i++)
            {
                CollectionAssert.AreEqual((List<string>)collections[i], (List<string>)GetProperties(entities[i]));
            }
        }

        private ICollection<string> GetProperties(IEntity entity)
        {
            List<string> result = new List<string>();
            Type type = entity.GetType();
            var properties = type.GetProperties();
            object[] attributes;
            foreach (var item in properties)
            {
                attributes = item.GetCustomAttributes(false);
                foreach (Attribute attribute in attributes)
                {
                    if (attribute is DbAttributeNameAttribute nameAttribute)
                    {
                        result.Add(nameAttribute.AttributeName);
                    }
                }
            }
            return result;
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

        [TestMethod]
        public void GetPropertiesValuesOfEntity_ReturnCollectionOfPropertiesValuesInRightOrder()
        {
            // arrange
            IEntity entity = new DbEntry();
            PropertiesDbProvider provider = new PropertiesDbProvider();

            // act
            ICollection<string> result = provider.GetPropertiesValuesOfEntityInRightOrder(entity, provider.GetProperties(entity));

            // assert
            CollectionAssert.AreEqual((List<string>)result, (List<string>)GetPropertiesValuesInRighrOrder(entity, GetProperties(entity)));

        }

        private ICollection<string> GetPropertiesValuesInRighrOrder(IEntity entity, ICollection<string> propertiesNames)
        {

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
