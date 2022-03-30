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

        protected string GetPropertiesWithoutProperty(IEntity entity, string propertyName)
        {
            return null;
        }
    }
}
