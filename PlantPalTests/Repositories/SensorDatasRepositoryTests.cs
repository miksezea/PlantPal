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
        public void AddTest()
        {
            
        }





        
    }
}