using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager.DAL.Entities;
using PasswordManager.DAL.Repositories;
using PasswordManager.DAL.Repositories.Interfaces;
using PasswordManager.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Tests
{
    [TestClass]
    public class RockPaperScissorsTests
    {
        [TestMethod]
        public void GetWinningVariant_EqualVariants_ReturnReceivedVariant()
        {
            // arrange
            RockPaperScissors game = new RockPaperScissors();
            ChoiceVariant firstVariant = ChoiceVariant.Stone;
            ChoiceVariant secondVariant = ChoiceVariant.Stone;

            // act
            ChoiceVariant result = game.GetWinningVariant(firstVariant, secondVariant);

            // assert

            Assert.AreEqual(firstVariant, result);
            Assert.AreEqual(secondVariant, result);
        }
    }
}
