using KneatChallenge.Models;
using KneatChallenge.Services.StopCalculator.impl;
using NUnit.Framework;
using System.Collections;

namespace KneatChallenge.Tests.UnitTests

{
    [TestFixture]
    public class StopCalculatorImplTest
    {
        [TestCase("40", "6 years", 1000000, 0)]
        [TestCase("70", "1 month", 1000000, 19)]
        [TestCase("10", "3 years", 1000000, 3)]
        [TestCase("75", "2 months", 1000000, 9)]
        [TestCase("80", "1 week", 1000000, 74)]
        [TestCase("105", "5 days", 500000, 39)]
        [TestCase("70", "1 month", 500000, 9)]
        [TestCase("50", "2 months", 500000, 6)]
        [TestCase("40", "2 years", 500000, 0)]
        [TestCase("60", "2 years", 500000, 0)]
        [TestCase("120", "1 week", 500000, 24)]
        [TestCase("91", "1 week", 500000, 32)]
        public void AmountStopRequired(string MGLT, string consumables, long distance, int result)
        {
            Starship starship = new Starship() { name = "test", MGLT = MGLT, consumables = consumables };
            StopCalculatorImpl stopcalculatorImpl = new StopCalculatorImpl();
            Assert.AreEqual(result, stopcalculatorImpl.getAmountStopRequired(starship, distance));
        }



    }
}