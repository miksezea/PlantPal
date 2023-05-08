namespace PlantPalLib.Models
{
    public class SensorData
    {
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
        public void ValidateHumidity()
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            ValidatePHValue();
            
        }
    }
}