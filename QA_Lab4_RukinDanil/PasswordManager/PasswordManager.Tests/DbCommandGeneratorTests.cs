using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager.DAL.Repositories;
using PasswordManager.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Tests
{
    [TestClass]
    public class DbCommandGeneratorTests
    {
        [TestMethod]
        public void Get_ReturnValidCommand()
        {
            // arrange
            DbAttributesPropertiesProvider provider = new DbAttributesPropertiesProvider();
            IDbCommandBuilder commandGenerator = new PgDbCommandGenerator(provider);
            int entityId = 1;

            // act
            string result = commandGenerator.Get(entityId);

            // assert
            Assert.AreEqual(result, $"");
        }
    }
}
