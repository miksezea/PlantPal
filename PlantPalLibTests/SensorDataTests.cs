using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantPalLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace PlantPalLib.Tests
{
    [TestClass()]
    public class SensorDataTests
    {
        int highestValue = 14;
        int lowestValue = 0;
        SensorData correctPh = new SensorData() { PHValue = 0, Humidity = 50 };
        SensorData correctPh2 = new SensorData() { PHValue = 14, Humidity = 50 };
        SensorData wrongPh = new SensorData() { PHValue = -1, Humidity = -1 };
        SensorData wrongPh2 = new SensorData() { PHValue = 15, Humidity = 101 };
        SensorData middle = new SensorData() { PHValue = 7, Humidity = 50 };
        

        [TestMethod()]
        public void ValidatePHValueShouldPass()
        {
            correctPh.ValidatePHValue();
            correctPh2.ValidatePHValue();

            Assert.IsTrue(correctPh.PHValue >= lowestValue && correctPh.PHValue <= highestValue);
            Assert.IsTrue(correctPh2.PHValue >= lowestValue && correctPh2.PHValue <= highestValue);
        }

        [TestMethod()]
        public void ValidatePHValueShouldFail()
        {
            correctPh.ValidatePHValue();
            
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongPh.ValidatePHValue());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongPh2.ValidatePHValue());
        }


        
        [TestMethod()]
        public void ValidateHumidityShouldPass()
        {
            correctPh.ValidateHumidityValue();
            correctPh2.ValidateHumidityValue();

            Assert.IsTrue(correctPh.Humidity >= 0 && correctPh.Humidity <= 100);
            Assert.IsTrue(correctPh2.Humidity >= 0 && correctPh2.Humidity <= 100);
            Assert.IsTrue(middle.Humidity >= 0 && middle.Humidity <= 100);
        }

        [TestMethod()]
        public void ValidateHumidityShouldFail()
        {
            correctPh.ValidateHumidityValue();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongPh.ValidateHumidityValue());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongPh2.ValidateHumidityValue());
        }
        
        
    }
}