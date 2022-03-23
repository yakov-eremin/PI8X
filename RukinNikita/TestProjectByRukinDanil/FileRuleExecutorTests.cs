using FileManager.Models.Services.Executors;
using FileManager.Models.Services.FileRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectByRukinDanil
{
    [TestClass]
    public class FileRuleExecutorTests
    {
        [TestMethod]
        public void Add_RuleIsAlreadyExists_ShouldReturnFalse()
        {
            // arrange
            FileRuleExecutor ruleExecutor = new FileRuleExecutor();
            ruleExecutor.Add(new LowerCaseRule());
            // act
            bool result = ruleExecutor.Add(new LowerCaseRule());
            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Add_AddingDifferentRules_ReturnTrue()
        {
            // arrange
            FileRuleExecutor executor = new FileRuleExecutor();
            executor.Add(new LowerCaseRule());
            // act
            bool result = executor.Add(new UpperCaseRule());
            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Add_RuleIsNull_ShouldThrowArgumentNullException()
        {
            // arrange
            FileRuleExecutor executor = new FileRuleExecutor();
            // act
            var result = Assert.ThrowsException<ArgumentNullException>(() => executor.Add(null));
            // assert
            Assert.IsInstanceOfType(result, typeof(ArgumentNullException));
        }

        [TestMethod]
        public void Remove_NothingToRemove_ReturnFalse()
        {
            // arrange
            FileRuleExecutor executor= new FileRuleExecutor();
            // act
            bool result = executor.Remove(new UpperCaseRule());
            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Remove_TryToRemoveNull_ShouldThrowArgumentNullException()
        {
            // arrange
            FileRuleExecutor executor = new FileRuleExecutor();
            // act
            var result = Assert.ThrowsException<ArgumentNullException>(() => executor.Remove(null));
            // assert
            Assert.IsInstanceOfType(result, typeof(ArgumentNullException));
        }

        [TestMethod]
        public void Remove_RemoveAnExistingRule_ReturnTrue()
        {
            // arrange
            FileRuleExecutor executor = new FileRuleExecutor();
            executor.Add(new UpperCaseRule());
            executor.Add(new LowerCaseRule());
            executor.Add(new LimitFileNameLengthRule(5));
            // act
            bool result = executor.Remove(new UpperCaseRule());
            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Invoke_UseUpperCaseRule_ShouldRenameOnlyNameOfFile()
        {
            // arrange
            FileRuleExecutor executor = new FileRuleExecutor();
            UpperCaseRule rule = new UpperCaseRule();
            executor.Add(rule);
            string directory = @"D:\test\";
            string fileName = "fileName";
            string ext = ".txt";
            string path = Path.Combine(directory, fileName + ext);
            // act
            string result = executor.Invoke(path);
            // assert
            Assert.AreEqual(Path.Combine(directory, fileName.ToUpper() + ext), result);
        }
    }
}
