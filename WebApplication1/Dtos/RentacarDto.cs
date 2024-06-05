using WebApplication1.Models;

namespace WebApplication1.Dtos
{
    public class RentacarDto
    {
        public int? Id { get; set; }

        public int CarId { get; set; }
  

        public DateTime VerilmeTarihi { get; set; }

        public DateTime TeslimTarihi { get; set; }

        public string Fiyat { get; set; }
    }
}
