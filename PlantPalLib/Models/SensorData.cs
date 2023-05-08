namespace PlantPalLib.Models
{
    public class SensorData
    {
        public string? DateTime { get; set; }
        public float PHValue { get; set; }
        public int Humidity { get; set; }

        public void ValidatePHValue()
        {
            throw new NotImplementedException();
        }
        public void ValidateHumidity()
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}