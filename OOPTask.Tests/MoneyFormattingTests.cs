using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OOPTask.Output;

namespace OOPTask.Tests
{
    [TestFixture]
    internal class MoneyFormattingTests
    {
        public decimal[] ExpectedDecimals { get; set; }
        [Test]
        [TestCase(0, new [] {0, 0})]
        [TestCase(0.1, new [] {0, 10})]
        [TestCase(1.0, new [] {1, 0})]
        [TestCase(1.1, new [] {1, 10})]
        [TestCase(1, new [] {1, 0})]
        [TestCase(0.01, new [] {0, 1})]
        [TestCase(0.11, new [] {0, 11})]
        [TestCase(1.11, new [] {1, 11})]
        public void SplitDecimalToString_WhenCalledWithCorrectInput_CorrectFormatting(decimal money, int[] expectedResult)
        {
            var result = MoneyFormatting.SplitDecimalToString(money);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(0.001, new[] { 0, 0 })]
        [TestCase(0.101, new[] { 0, 10 })]
        public void SplitDecimalToString_WhenCalledWithIncorrectInput_IncorrectFormatting(decimal money, int[] expectedResult)
        {
            var result = MoneyFormatting.SplitDecimalToString(money);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
