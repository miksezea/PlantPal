using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            SensorData newSensorData = new SensorData { Conductivity = 60, Moisture = 7 };

            // Act
            SensorData addedSensorData = repository.Add(newSensorData);

            // Assert
            Assert.IsNotNull(addedSensorData);
            Assert.AreEqual(newSensorData.Conductivity, addedSensorData.Conductivity);
            Assert.AreEqual(newSensorData.Moisture, addedSensorData.Moisture);
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





        
    
