using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantPalLib.Models;

namespace PlantPalLib.Tests
{ 
    [TestClass()]
    public class SensorDataTests
    {
        int highestValue;
        int lowestValue;        
        SensorData correctData = new SensorData() { Moisture = 0, Conductivity = 0, Temperature = -273 };
        SensorData correctData2 = new SensorData() { Moisture = 100, Conductivity = 123456, Temperature = 41 };
        SensorData middledata = new SensorData() { Moisture = 50 };
        SensorData wrongData = new SensorData() { Moisture = -1, Conductivity = -1, Temperature = -274 };
        SensorData wrongData2 = new SensorData() { Moisture = 101 };
        
        [TestMethod()]
        public void ValidateMoistureValueShouldPass()
        {
            highestValue = 100;
            lowestValue = 0;           
            correctData.ValidateMoistureValue();
            correctData2.ValidateMoistureValue();
            middledata.ValidateMoistureValue();

            Assert.IsTrue(correctData.Moisture >= lowestValue && correctData.Moisture <= highestValue);
            Assert.IsTrue(correctData2.Moisture >= lowestValue && correctData2.Moisture <= highestValue);
            Assert.IsTrue(middledata.Moisture >= lowestValue && middledata.Moisture <= highestValue);
        }

        [TestMethod()]
        public void ValidateMoistureShouldFail()
        {            
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongData.ValidateMoistureValue());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongData2.ValidateMoistureValue());
        }

        [TestMethod()]
        public void ValidateConductivityShouldPass()
        {
            lowestValue = 0;
            correctData.ValidateConductivityValue();
            correctData2.ValidateConductivityValue();

            Assert.IsTrue(correctData.Conductivity >= lowestValue);
            Assert.IsTrue(correctData2.Conductivity >= lowestValue);            
        }

        [TestMethod()]
        public void ValidateConductivityValueShouldFail()
        {                        
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongData.ValidateConductivityValue());          
        }

        [TestMethod()]
        public void ValidateTemperatureValueShouldPass()
        {
            lowestValue = -273;
            correctData.ValidateTemperature();
            correctData2.ValidateTemperature();

            Assert.IsTrue(correctData.Temperature >= lowestValue);
            Assert.IsTrue(correctData2.Temperature >= lowestValue);
        }

        [TestMethod()]
        public void ValidateTemperatureValueShouldFail()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongData.ValidateTemperature());
        }
    }
}