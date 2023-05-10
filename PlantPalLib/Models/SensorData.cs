namespace PlantPalLib.Models
{
    /// <summary>
    /// Klassen for en måling fra sensor
    /// </summary>
    public class SensorData
    {
        /// <summary>
        /// Unikt Id for målingen
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Dato og tid for målingen
        /// </summary>
        public string? DateTime { get; set; }

        /// <summary>
        /// Fugtighed i jorden i [%]
        /// </summary>
        public double Moisture { get; set; }

        /// <summary>
        /// Konduktivitet/Fertilitet af jorden i [µS/cm]
        /// </summary>
        public double Conductivity { get; set; }

        /// <summary>
        /// Mængden af lys på planten i [lux]
        /// </summary>
        public double Light { get; set; }

        /// <summary>
        /// Luftens temperatur omkring planten i [Celsius]
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Tjekker at Moisture har en lovlig value
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Hvis</exception>
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
       
        public void ValidateLightValue()
        {
            if (Light < 0)
            {
                throw new ArgumentOutOfRangeException();
            }                
        }

        public void ValidateTemperature()
        {
            if(Temperature < -273)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Validate()
        {
            ValidateMoistureValue();
            ValidateConductivityValue();
            ValidateLightValue();
            ValidateTemperature();
        }

        public override string ToString()
        {
            return $"Id: {this.Id}, DateTime: {this.DateTime}, Moisture: {this.Moisture}, Conductivity: {this.Conductivity}, Light: {this.Light}, Temperature: {this.Temperature}";
        }
    }
}