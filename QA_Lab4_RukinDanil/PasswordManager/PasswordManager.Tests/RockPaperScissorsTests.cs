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
            RockPaperScissors game = new SimpleRockPaperScissorsGameRealization();
            ChoiceVariant firstVariant = ChoiceVariant.Stone;
            ChoiceVariant secondVariant = ChoiceVariant.Stone;

            // act
            ChoiceVariant result = game.GetWinningVariant(firstVariant, secondVariant);

            // assert

            Assert.AreEqual(firstVariant, result);
            Assert.AreEqual(secondVariant, result);
        }

        [TestMethod]
        public void GetWinningVariant_StoneVsPaper_ReturnPaper()
        {
            // arrange
            RockPaperScissors game = new SimpleRockPaperScissorsGameRealization();
            ChoiceVariant stone = ChoiceVariant.Stone;
            ChoiceVariant paper = ChoiceVariant.Paper;

            // act
            ChoiceVariant result = game.GetWinningVariant(stone, paper);
            ChoiceVariant resultRevers = game.GetWinningVariant(paper, stone);

            // assert

            Assert.AreEqual(paper, result);
            Assert.AreEqual(paper, resultRevers);
        }

        [TestMethod]
        public void GetWinningVariant_StoneVsScissors_ReturnStone()
        {
            // arrange
            RockPaperScissors game = new SimpleRockPaperScissorsGameRealization();
            ChoiceVariant stone = ChoiceVariant.Stone;
            ChoiceVariant scissors = ChoiceVariant.Scissors;

            // act
            ChoiceVariant result = game.GetWinningVariant(stone, scissors);
            ChoiceVariant resultReverse = game.GetWinningVariant(scissors, stone);

            // assert

            Assert.AreEqual(stone, result);
            Assert.AreEqual(stone, resultReverse);
        }

        [TestMethod]
        public void GetWinningVariant_PaperVsScissors_ReturnScissors()
        {
            // arrange
            RockPaperScissors game = new SimpleRockPaperScissorsGameRealization();
            ChoiceVariant paper = ChoiceVariant.Paper;
            ChoiceVariant scissors = ChoiceVariant.Scissors;

            // act
            ChoiceVariant result = game.GetWinningVariant(paper, scissors);
            ChoiceVariant resultReverse = game.GetWinningVariant(scissors, paper);

            // assert

            Assert.AreEqual(scissors, result);
            Assert.AreEqual(scissors, resultReverse);
        }
    }
    /// <summary>
    /// Заглушка для тестирования методов проверки
    /// </summary>
    public class SimpleRockPaperScissorsGameRealization : RockPaperScissors
    {
        public override Guid GetAccessToken()
        {
            return Guid.Empty;
        }
    }
}
