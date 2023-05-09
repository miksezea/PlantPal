namespace PlantPalLib.Models
{
    public class SensorData
    {
        public int Id { get; set; }
        public string? DateTime { get; set; }
        public double Moisture { get; set; }
        public double Conductivity { get; set; }
        public double Light { get; set; }
        public double Temperature { get; set; }


        public void ValidateMoistureValue()
        {
            if (Moisture < 0 || Moisture > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public void ValidateConductivityValue()
        {
            if(Conductivity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void ValidateTemperatureValue()
        {
            
        }
        public void ValidateLightValue()
        {
            if (Light < 0)
                throw new ArgumentOutOfRangeException();
        }


        public void Validate()
        {
            ValidateMoistureValue();
            ValidateConductivityValue();
            ValidateTemperatureValue();
            ValidateLightValue();
        }
        public override string ToString()
        {
            return $"Id: {this.Id}, DateTime: {this.DateTime}, Moisture: {this.Moisture}, Conductivity: {this.Conductivity}, Light: {this.Light}, Temperature: {this.Temperature}";
        }
    }
}