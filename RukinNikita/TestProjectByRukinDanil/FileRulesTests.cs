using FileManager.Models.Services.FileRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectByRukinDanil
{
    [TestClass]
    public class FileRulesTests
    {
        [TestMethod]
        public void LimitFileNameRule_PatternLengthIsMoreThanConstraint_ResultLengthIsEqualWithConstraint()
        {
            // arrange
            int length = 5;
            LimitFileNameLengthRule rule = new LimitFileNameLengthRule(length);
            string pattern = "SomeFileWithLongName";
            // act
            string result = rule.Apply(pattern);
            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == length);
        }

        [TestMethod]
        public void LimitFileNameRule_EmptyPattern_ResultShouldBeEmptyString()
        {
            // arrange
            LimitFileNameLengthRule rule = new LimitFileNameLengthRule(5);
            // act
            string result = rule.Apply("");
            // assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void LimitFileNameRule_PatternLengthIsLessThanConstraint_ResultLengthShouldBeEqualWithPatternLength()
        {
            // arrange
            int constraint = 7;
            LimitFileNameLengthRule rule = new LimitFileNameLengthRule(constraint);
            string pattern = "five";
            // act
            string result = rule.Apply(pattern);
            // assert
            Assert.AreEqual(result.Length, pattern.Length);
        }
    }
}
