using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantPalLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantPalLib.Tests
{
    [TestClass()]
    public class SensorDataTests
    {
        SensorData correctPh = new SensorData() { PHValue = 14, Humidity = 50 };
        SensorData correctPh2 = new SensorData() { PHValue = 0, Humidity = 50 };
        SensorData wrongPh = new SensorData() { PHValue = -1, Humidity = 50 };
        SensorData wrongPh2 = new SensorData() { PHValue = 15, Humidity = 50 };

        [TestMethod()]
        public void ValidatePHValueShouldPass()
        {
            correctPh.ValidatePHValue();
            var actual = correctPh.PHValue;
            var actual2 = correctPh2.PHValue;

            Assert.AreEqual(14, actual);
            Assert.AreEqual(0, actual2);
        }

        [TestMethod()]
        public void ValidatePHValueShouldFail()
        {
            correctPh.ValidatePHValue();
            
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongPh.ValidatePHValue());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongPh2.ValidatePHValue());
        }

        [TestMethod()]
        public void ValidateHumidityTest()
        {
            Assert.Fail();
        }
    }
}