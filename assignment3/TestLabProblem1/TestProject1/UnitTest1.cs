using LabProblem1.models;
namespace TestProject1
{
    public class Tests
    {
        private cal _mnc { set; get; } = null;
        [SetUp]
        public void Setup()
        {
            _mnc = new cal();
        }

        [Test]
        public void Test1()
        {
            double initialBalance = 1000.0;
            int numberOfChecks = 25;
            double expectedResult = 12.0;


            var result = _mnc.CalculateServiceFees(initialBalance, numberOfChecks); // Fixed method name

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }
        [Test]
        public void Test2()
        {
            double initialBalance = 1000.0;
            int numberOfChecks = 15;
            double expectedResult = 11.5; // $10 monthly charge, no additional check fee

            var result = _mnc.CalculateServiceFees(initialBalance, numberOfChecks); // Fixed method name

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }
        [Test]
        public void Test3()
        {
            double initialBalance = 1000.0;
            int numberOfChecks = 30;
            double expectedResult = 12.4; // $10 monthly charge + $4 check fee

            var result = _mnc.CalculateServiceFees(initialBalance, numberOfChecks); // Fixed method name

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }
        [Test]
        public void Test4() { 
            double initialBalance = 1000.0;
            int numberOfChecks = 50;
            double expectedResult = 13.0;

            var result = _mnc.CalculateServiceFees(initialBalance, numberOfChecks); // Fixed method name

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }
        [Test]
        public void Test5()
        {
            double initialBalance = 1000.0;
            int numberOfChecks = 70;
            double expectedResult = 17.0;
            var result = _mnc.CalculateServiceFees(initialBalance, numberOfChecks); // Fixed method name

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }
        [Test]
        public void Test6()
        {
            double initialBalance = 300.0; // Below $400
            int numberOfChecks = 10;
            double expectedResult = 26.0;
            var result = _mnc.CalculateServiceFees(initialBalance, numberOfChecks); // Fixed method name

            Assert.AreEqual(expectedResult, result);
            Assert.That(result, Is.TypeOf<double>());
        }
    }
}