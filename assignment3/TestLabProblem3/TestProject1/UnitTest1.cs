using LabProblem3.models;

namespace TestProject1
{
    public class Tests
    {
        private calc _mnc { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            _mnc = new calc();
        }

        [Test]
        public void Test1()
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
