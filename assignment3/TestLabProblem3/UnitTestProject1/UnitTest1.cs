using LabProblem3.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private calc _mnc { get; set; } = new calc();
        

        [TestMethod]
        public void TestMethod1()
        {
            calc calculator = new calc();
            int initialPopulation = 1000;
            double increaseRate = 2.0;
            int noOfDays = 3;

            int result = calculator.CalculatePopulation(initialPopulation, increaseRate, noOfDays);

            // Assert
            int expectedPopulation = 1060;
            Assert.AreEqual(expectedPopulation, result);
        }
    }
}
