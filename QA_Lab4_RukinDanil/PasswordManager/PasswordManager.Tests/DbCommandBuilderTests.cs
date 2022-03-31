using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager.DAL.Entities;
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
    public class DbCommandBuilderTests
    {
        [TestMethod]
        public void Get_ReturnValidCommand()
        {
            // arrange
            DbAttributesPropertiesProvider provider = new DbAttributesPropertiesProvider();
            IDbCommandBuilder builder = new PgDbCommandBuilder();
            PgCrudCommandsGenerator generator = new PgCrudCommandsGenerator();
            int entityId = 1;

            // act
            string result = generator.CreateEntity(new DbEntry());

            // assert
            Assert.AreEqual(result, $"");
        }
    }
}
