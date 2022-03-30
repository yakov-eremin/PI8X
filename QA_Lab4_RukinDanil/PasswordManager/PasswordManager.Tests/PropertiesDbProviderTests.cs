using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager.DAL.Entities;
using PasswordManager.DAL.Repositories;

namespace PasswordManager.Tests
{
    [TestClass]
    public class PropertiesDbProviderTests
    {
        [TestMethod]
        public void GetPropertiesWithoutProperty_DbEntryDbAttributeName_ReturnValidPropertiesNames()
        {
            // arrange
            DbEntry entry = new DbEntry();
            PropertiesDbProvider provider = new PropertiesDbProvider();

            // act
            string result = provider.GetPropertiesWithoutProperty(entry, nameof(entry.Id));

            // assert
            Assert.AreEqual(GetPropertiesWithoutProperty(entry, nameof(entry.Id)), result);
        }

        private string GetPropertiesWithoutProperty(IEntity entity, string propertyName)
        {
            return null;
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
            IEntity entity = new WithoutAttribute();
            PropertiesDbProvider provider = new PropertiesDbProvider();

            // act
            bool result = provider.CheckDbTableNameAttribute(entity);

            // assert
            Assert.IsFalse(result);
        }
    }

    public class WithoutAttribute : IEntity
    {
        public int Id { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
