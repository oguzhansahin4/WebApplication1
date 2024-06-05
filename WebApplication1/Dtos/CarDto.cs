using WebApplication1.Models;

namespace WebApplication1.Dtos
{
    public class CarDto
    {
        public int? Id { get; set; }
        public string ArabaAdi { get; set; }
        public string ArabaModel { get; set; }
        public string ArabaKm { get; set; }
        public string ArabaYakıtTürü { get; set; }
        public string ArabaResim { get; set; }

        public int BrandId { get; set; }

        
    }
}
