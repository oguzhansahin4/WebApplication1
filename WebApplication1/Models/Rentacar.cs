namespace WebApplication1.Models
{
    public class Rentacar
    {
        public int Id { get; set; }

        public int CarId { get; set; }  
        public Car Car { get; set; }

        public DateTime VerilmeTarihi { get; set; }

        public DateTime TeslimTarihi { get; set; }

        public string Fiyat { get; set; }  
    }
}
