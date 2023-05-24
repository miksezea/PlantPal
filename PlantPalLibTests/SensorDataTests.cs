using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantPalLib.Models;

namespace PlantPalLib.Tests
{ 
    [TestClass]
    public class SensorDataTests
    {
        private int highestValue;
        private int lowestValue;

		private SensorData correctData;
		private SensorData correctData2;
		private SensorData middleData;
		private SensorData wrongData;
		private SensorData wrongData2;

        [TestInitialize]
        public void Initialize() // Kører før hver test
        {
			highestValue = 100;
			lowestValue = 0;

			correctData = new SensorData { Moisture = 0, Conductivity = 0, Temperature = -273 };
			correctData2 = new SensorData { Moisture = 100, Conductivity = 123456, Temperature = 41 };
			middleData = new SensorData { Moisture = 50 };
			wrongData = new SensorData { Moisture = -1, Conductivity = -1, Temperature = -274 };
			wrongData2 = new SensorData { Moisture = 101 };
		}

		[TestMethod]
		public void ValidateMoistureValue_ShouldPass() 
		{
			correctData.ValidateMoistureValue();
			correctData2.ValidateMoistureValue(); 
			middleData.ValidateMoistureValue(); 

			Assert.IsTrue(correctData.Moisture >= lowestValue && correctData.Moisture <= highestValue); // Tester om Moisture er større end eller lig med lowestValue og mindre end eller lig med highestValue
			Assert.IsTrue(correctData2.Moisture >= lowestValue && correctData2.Moisture <= highestValue); // Tester om Moisture er større end eller lig med lowestValue og mindre end eller lig med highestValue
			Assert.IsTrue(middleData.Moisture >= lowestValue && middleData.Moisture <= highestValue); // Tester om Moisture er større end eller lig med lowestValue og mindre end eller lig med highestValue
		}

		[TestMethod]
		public void ValidateMoistureValue_ShouldFail() 
		{
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongData.ValidateMoistureValue()); // Tester om metoden kaster en ArgumentOutOfRangeException
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongData2.ValidateMoistureValue()); // Tester om metoden kaster en ArgumentOutOfRangeException
		}

		[TestMethod]
		public void ValidateConductivityValue_ShouldPass()
		{
			lowestValue = 0; // Conductivity kan ikke være mindre end 0

			correctData.ValidateConductivityValue(); // Tester om metoden kaster en ArgumentOutOfRangeException
			correctData2.ValidateConductivityValue(); // Tester om metoden kaster en ArgumentOutOfRangeException

			Assert.IsTrue(correctData.Conductivity >= lowestValue); // Tester om Conductivity er større end eller lig med lowestValue
			Assert.IsTrue(correctData2.Conductivity >= lowestValue); // Tester om Conductivity er større end eller lig med lowestValue
		}

		[TestMethod]
		public void ValidateConductivityValue_ShouldFail()
		{
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongData.ValidateConductivityValue()); // Tester om metoden kaster en ArgumentOutOfRangeException
		}

		[TestMethod]
		public void ValidateTemperatureValue_ShouldPass()
		{
			lowestValue = -273; // Temperature kan ikke være mindre end -273

			correctData.ValidateTemperature(); // Tester om metoden kaster en ArgumentOutOfRangeException
			correctData2.ValidateTemperature(); // Tester om metoden kaster en ArgumentOutOfRangeException

			Assert.IsTrue(correctData.Temperature >= lowestValue); // Tester om Temperature er større end eller lig med lowestValue
			Assert.IsTrue(correctData2.Temperature >= lowestValue); // Tester om Temperature er større end eller lig med lowestValue
		}

		[TestMethod]
		public void ValidateTemperatureValue_ShouldFail()
		{
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongData.ValidateTemperature()); // Tester om metoden kaster en ArgumentOutOfRangeException
		}
	}
}