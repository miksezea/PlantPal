using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantPalLib.Models;

namespace PlantPal.Repositories.Tests
{
    [TestClass]
    public class SensorDatasRepositoryTests
    {
        private SensorDatasRepository repository; // Deklarerer en privat variabel af typen SensorDatasRepository

		[TestInitialize]
        public void Initialize()
        {
            _repository = new SensorDatasRepository(); // Instantierer en ny instans af klassen SensorDatasRepository
        }

        [TestMethod]
        public void GetAllTest()
        {
            // Act
            var result = repository.GetAll(); // Kalder metoden GetAll() på instansen af klassen SensorDatasRepository

			// Assert
			Assert.IsNotNull(result); // Tester om resultatet er forskelligt fra null
			Assert.IsInstanceOfType(result, typeof(List<SensorData>)); // Tester om resultatet er af typen List<SensorData>
			Assert.AreEqual(3, result.Count); // Tester om resultatet indeholder 3 elementer
		}

        [TestMethod]
		public void GetByIdTest()
        {
			// Arrange
			int id = 1; // Deklarerer en variabel af typen int med værdien 1

			// Act
			SensorData result = repository.GetById(id); // Kalder metoden GetById() på instansen af klassen SensorDatasRepository

			// Assert
			Assert.IsNotNull(result); // Tester om resultatet er forskelligt fra null
			Assert.AreEqual(id, result.Id); // Tester om resultatet er lig med variablen id
		}

        [TestMethod]
		public void GetByIdTest_InvalidId_ReturnsNull()
        {
			// Arrange
			int id = 0; // Deklarerer en variabel af typen int med værdien 0

			// Act
			SensorData result = repository.GetById(id); // Kalder metoden GetById() på instansen af klassen SensorDatasRepository

			// Assert
			Assert.IsNull(result); // Tester om resultatet er lig med null
		}

        [TestMethod]
		public void DeleteTest()
        {
			// Arrange
			int id = 1; // Deklarerer en variabel af typen int med værdien 1

			// Act
			SensorData result = repository.Delete(id); // Kalder metoden Delete() på instansen af klassen SensorDatasRepository

			// Assert
			Assert.IsNotNull(result); // Tester om resultatet er forskelligt fra null
			Assert.AreEqual(id, result.Id); // Tester om resultatet er lig med variablen id
		}

        [TestMethod]
		public void DeleteTest_InvalidId_ReturnsNull()
        {
			// Arrange
			int id = 0; // Deklarerer en variabel af typen int med værdien 0

			// Act
			SensorData result = repository.Delete(id); // Kalder metoden Delete() på instansen af klassen SensorDatasRepository

			// Assert
			Assert.IsNull(result); // Tester om resultatet er lig med null
        }

        [TestMethod]
        public void AddTest_NewSensorData()
        {
            // Arrange
            SensorData newSensorData = new SensorData { Conductivity = 60, Moisture = 7 }; // Deklarerer en ny instans af klassen SensorData med værdierne 60 og 7

            // Act
            SensorData addedSensorData = repository.Add(newSensorData); // Kalder metoden Add() på instansen af klassen SensorDatasRepository

            // Assert
            Assert.IsNotNull(addedSensorData); // Tester om resultatet er forskelligt fra null
            Assert.AreEqual(newSensorData.Conductivity, addedSensorData.Conductivity); // Tester om resultatet er lig med variablen newSensorData.Conductivity
            Assert.AreEqual(newSensorData.Moisture, addedSensorData.Moisture); // Tester om resultatet er lig med variablen newSensorData.Moisture
            Assert.AreEqual(repository._nextId - 1, addedSensorData.Id); // Tester om resultatet er lig med variablen repository._nextId - 1
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] // Forventer at metoden kaster en ArgumentNullException
        public void Add_NullSensorData_ThrowsArgumentNullException() 
        {
            // Arrange
            SensorDatasRepository repository = new SensorDatasRepository(); // Instantierer en ny instans af klassen SensorDatasRepository

            // Act
            SensorData addedSensorData = repository.Add(null); // Kalder metoden Add() på instansen af klassen SensorDatasRepository
        }
    }
}





        
    
