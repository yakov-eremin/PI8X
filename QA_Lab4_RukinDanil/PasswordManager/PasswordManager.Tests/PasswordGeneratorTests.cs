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

        [TestMethod]
        public void Generate_PasswordLengthInOptinsIsMoreThanOtherOptionsParametersCount_GeneratedPasswordLengthShouldBeEqualToOptionsLength()
        {
            IPasswordGenerator generator = new PasswordGenerator();
            GenerationOptions options = new GenerationOptions();
            options.UpperCaseSymbolsCount = 5;
            options.LowerCaseSymbolsCount = 5;
            options.SpecialSymbols = new List<char>() { '@', '!', '#' };
            options.DigitsCount = 7;
            options.Length = 24;
            generator.ConfigureParameters(options);

            // act
            string password = generator.Generate();

            // assert
            Assert.AreEqual(options.Length, password.Length);
        }

        [TestMethod]
        public void Generate_ContainsNesessaryAmountOfDigit()
        {
            // arrange
            IPasswordGenerator generator = new PasswordGenerator();
            GenerationOptions options = new GenerationOptions();
            int digitsCount = 10;
            options.DigitsCount = digitsCount;
            options.UpperCaseSymbolsCount = 2;
            options.Length = 12;
            generator.ConfigureParameters(options);

            // act
            string password = generator.Generate();

            // assert
            int amount = 0;
            foreach (char symbol in password)
            {
                if (symbol >= '0' && symbol <= '9')
                    amount++;
            }
            Assert.AreEqual(digitsCount, amount);
        }

        [TestMethod]
        public void Generate_OptionsLengthIsEqualToMinimalPossibleLength_GeneratedPasswordsLengthShouldBeEqulaToOptionsLength()
        {
            // arrange
            IPasswordGenerator generator = new PasswordGenerator();
            GenerationOptions options = new GenerationOptions();
            options.UpperCaseSymbolsCount = 5;
            options.LowerCaseSymbolsCount = 5;
            options.SpecialSymbols = new List<char>() { '@', '!', '#' };
            options.DigitsCount = 7;
            options.Length = options.UpperCaseSymbolsCount + options.LowerCaseSymbolsCount + options.DigitsCount
                + options.SpecialSymbols.Count;
            generator.ConfigureParameters(options);

            // act
            string password = generator.Generate();

            // assert
            Assert.AreEqual(options.Length, password.Length);

        }

        [TestMethod]
        public void Generate_GeneratedPasswordContainsAllSelectedSpecialSymbols()
        {
            // arrange
            IPasswordGenerator generator = new PasswordGenerator();
            GenerationOptions options = new GenerationOptions();
            options.UpperCaseSymbolsCount = 5;
            options.LowerCaseSymbolsCount = 5;
            options.SpecialSymbols = new List<char>() { '@', '!', '#' };
            options.DigitsCount = 7;
            options.Length = options.UpperCaseSymbolsCount + options.LowerCaseSymbolsCount + options.DigitsCount
                + options.SpecialSymbols.Count;
            generator.ConfigureParameters(options);

            // act
            string password = generator.Generate();

            // assert
            bool isContains = true;
            foreach (var item in options.SpecialSymbols)
            {
                isContains = isContains && password.Contains(item);
            }
            Assert.IsTrue(isContains);
        }

        [TestMethod]
        public void Generate_PasswordContainsNesassryAmountOfLowerCaseSymbols()
        {
            // arrange
            IPasswordGenerator generator = new PasswordGenerator();
            GenerationOptions options = new GenerationOptions();
            options.UpperCaseSymbolsCount = 5;
            int lowerCaseCount = 5;
            options.LowerCaseSymbolsCount = lowerCaseCount;
            options.SpecialSymbols = new List<char>() { '@', '!', '#' };
            options.DigitsCount = 7;
            options.Length = options.UpperCaseSymbolsCount + options.LowerCaseSymbolsCount + options.DigitsCount
                + options.SpecialSymbols.Count;
            generator.ConfigureParameters(options);

            // act
            string password = generator.Generate();

            // assert
            int amount = 0;
            foreach (char symbol in password)
            {
                if (char.IsLower(symbol))
                    amount++;
            }
            Assert.AreEqual(lowerCaseCount, amount);
        }

        [TestMethod]
        public void Generate_OptionsLengthMoreThanMinimalPossibleLength_PasswordContainsMoreLowerCaseSymbolsThanSpecifiedInOptions()
        {
            // arrange
            IPasswordGenerator generator = new PasswordGenerator();
            GenerationOptions options = new GenerationOptions();
            options.UpperCaseSymbolsCount = 5;
            int lowerCaseCount = 5;
            options.LowerCaseSymbolsCount = lowerCaseCount;
            options.SpecialSymbols = new List<char>() { '@', '!', '#' };
            options.DigitsCount = 7;
            int difference = 10;
            options.Length = options.UpperCaseSymbolsCount + options.LowerCaseSymbolsCount + options.DigitsCount
                + options.SpecialSymbols.Count + difference;
            generator.ConfigureParameters(options);

            // act
            string password = generator.Generate();

            // assert
            int amount = 0;
            foreach (char symbol in password)
            {
                if (char.IsLower(symbol))
                    amount++;
            }
            Assert.AreEqual(lowerCaseCount + difference, amount);
        }
    }
}
