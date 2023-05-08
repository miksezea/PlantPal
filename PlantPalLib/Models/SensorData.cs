namespace PlantPalLib.Models
{
    public class SensorData
    {
        public int Id { get; set; }
        public string? DateTime { get; set; }
        public float PHValue { get; set; }
        public int Humidity { get; set; }

        public void ValidatePHValue()
        {
            if (PHValue < 0 || PHValue > 14)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public void ValidateHumidityValue()
        {
            if(Humidity < 0 || Humidity > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Validate()
        {
            ValidatePHValue();
            ValidateHumidityValue();
        }
    }
}