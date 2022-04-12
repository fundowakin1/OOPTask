using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OOPTask.GameEntities.Players;

namespace OOPTask.Tests
{
    [TestFixture]
    internal class PlayerTests
    {
        [Test]
        [TestCase(10,110)]
        [TestCase(0,100)]
        [TestCase(1,101)]
        public void ReceiveMoney_WhenCalled_CorrectReceiving(decimal amountOfMoneyToReceive, decimal expectedResult)
        {
            var player = new Player();

            player.ReceiveMoney(amountOfMoneyToReceive);
            
            var result = player.AmountOfMoney;

            Assert.AreEqual(expectedResult, result);
        }[Test]
        [TestCase(10,90)]
        [TestCase(0,100)]
        [TestCase(1,99)]
        public void GiveMoney_WhenCalled_CorrectReceiving(decimal amountOfMoneyToGive, decimal expectedResult)
        {
            var player = new Player();

            player.GiveMoney(amountOfMoneyToGive);
            
            var result = player.AmountOfMoney;

            Assert.AreEqual(expectedResult, result);
        }
    }
}
