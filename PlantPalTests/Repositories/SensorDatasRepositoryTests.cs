using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantPal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantPal.Repositories;
using PlantPalLib.Models;

namespace PlantPal.Repositories.Tests
{
    [TestClass()]
    public class SensorDatasRepositoryTests
    {
        private SensorDatasRepository repository;
        [TestInitialize]
        public void BeforeEachTest()
        {
            repository = new SensorDatasRepository();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var actual = repository.GetAll();
            Assert.IsNotNull(actual);
            Assert.AreEqual(typeof(List<SensorData>), actual.GetType());
            Assert.AreEqual(3, actual.Count());
        }

        [TestMethod()]
        public void AddTest_NewSensorData()
        {
            // Arrange
            SensorDatasRepository repository = new SensorDatasRepository();
            SensorData newSensorData = new SensorData { Humidity = 60, PHValue = 7 };

            // Act
            SensorData addedSensorData = repository.Add(newSensorData);

            // Assert
            Assert.IsNotNull(addedSensorData);
            Assert.AreEqual(newSensorData.Humidity, addedSensorData.Humidity);
            Assert.AreEqual(newSensorData.PHValue, addedSensorData.PHValue);
            Assert.AreEqual(repository._nextId - 1, addedSensorData.Id);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullSensorData_ThrowsArgumentNullException()
        {
            // Arrange
            SensorDatasRepository repository = new SensorDatasRepository();

            // Act
            SensorData addedSensorData = repository.Add(null);
        }





        
    }
}





        
    
