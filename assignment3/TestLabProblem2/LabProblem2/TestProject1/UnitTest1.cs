using LabProblem2.models;
namespace TestProject1
{
    public class Tests
    {
        private calc _mnc { set; get; } = null;

        [SetUp]
        public void Setup()
        {
            _mnc = new calc();
        }

        [Test]
        public void Test1()
        {
            calc calculator = new calc();

            double charges1 = calculator.CalculateShippingCharges(1, 250); 
            double charges2 = calculator.CalculateShippingCharges(5, 750); 
            double charges3 = calculator.CalculateShippingCharges(8, 1500); 
            double charges4 = calculator.CalculateShippingCharges(15, 300); 

            Assert.AreEqual(1.10, charges1, "Charges for weight 1 and distance 250 should be 1.10");
            Assert.AreEqual(4.4, charges2, "Charges for weight 5 and distance 750 should be 2.20");
            Assert.AreEqual(3.70, charges3, "Charges for weight 8 and distance 1500 should be 3.70");
            Assert.AreEqual(4.80, charges4, "Charges for weight 15 and distance 300 should be 4.80");
        }
    }
}