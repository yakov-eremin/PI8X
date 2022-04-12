using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManager.Core.Services;
using PasswordManager.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Tests
{
    [TestClass]
    public class PasswordGeneratorTests
    {
        [TestMethod]
        public void Generate_ContainsNesessaryAmountOfUpperCaseSymbols()
        {
            // arrange
            IPasswordGenerator generator = new PasswordGenerator();
            GenerationOptions options = new GenerationOptions();
            int upperCaseSymbolsCount = 10;
            options.UpperCaseSymbolsCount = upperCaseSymbolsCount;
            options.Length = 12;
            generator.ConfigureParameters(options);

            // act
            string password = generator.Generate();

            // assert
            int amount = 0;
            foreach (char symbol in password)
            {
                if (char.IsUpper(symbol))
                    amount++;
            }
            Assert.AreEqual(upperCaseSymbolsCount, amount);
        }

        [TestMethod]
        public void ConfigureParameters_PasswordLengthLessThanMinimalPossibleLength_ThrowInvalidOperationException()
        {
            // arrange
            IPasswordGenerator generator = new PasswordGenerator();
            GenerationOptions options = new GenerationOptions();
            options.UpperCaseSymbolsCount = 5;
            options.LowerCaseSymbolsCount = 5;
            options.SpecialSymbols = new List<char>() { '@', '!', '#'};
            options.DigitsCount = 7;
            options.Length = 12;            

            // act
            var result = Assert.ThrowsException<InvalidOperationException>(() => generator.ConfigureParameters(options));

            // assert
            Assert.AreEqual(typeof(InvalidOperationException), result.GetType());
        }

        public void ConfigureParameters_PasswordLengthLessThanOne_ThrowArgumentException()
        {

        }
    }
}
