using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantPalLib.Models;

namespace PlantPalLib.Tests
{
    [TestClass()]
    public class SensorDataTests
    {
        int highestValue = 14;
        int lowestValue = 0;
        SensorData correctMoisture = new SensorData() { Moisture = 0, Conductivity = 50 };
        SensorData correctMoisture2 = new SensorData() { Moisture = 14, Conductivity = 50 };
        SensorData wrongMoisture = new SensorData() { Moisture = -1, Conductivity = -1 };
        SensorData wrongMoisture2 = new SensorData() { Moisture = 101, Conductivity = -1 };
        SensorData middle = new SensorData() { Moisture = 7, Conductivity = 50 };
        
        [TestMethod()]
        public void ValidateMoistureValueShouldPass()
        {
            correctMoisture.ValidateMoistureValue();
            correctMoisture2.ValidateMoistureValue();

            Assert.IsTrue(correctMoisture.Moisture >= lowestValue && correctMoisture.Moisture <= highestValue);
            Assert.IsTrue(correctMoisture2.Moisture >= lowestValue && correctMoisture2.Moisture <= highestValue);
        }

        [TestMethod()]
        public void ValidateMoistureShouldFail()
        {
            correctMoisture.ValidateMoistureValue();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongMoisture.ValidateMoistureValue());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongMoisture2.ValidateMoistureValue());
        }

        [TestMethod()]
        public void ValidateConductivityShouldPass()
        {
            correctMoisture.ValidateConductivityValue();
            correctMoisture2.ValidateConductivityValue();

            Assert.IsTrue(correctMoisture.Conductivity >= 0 && correctMoisture.Conductivity <= 100);
            Assert.IsTrue(correctMoisture2.Conductivity >= 0 && correctMoisture2.Conductivity <= 100);
            Assert.IsTrue(middle.Conductivity >= 0 && middle.Conductivity <= 100);
        }

        [TestMethod()]
        public void ValidateConductivityValueShouldFail()
        {
            correctMoisture.ValidateConductivityValue();
            
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongMoisture.ValidateConductivityValue());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongMoisture2.ValidateConductivityValue());
        }    
    }
}