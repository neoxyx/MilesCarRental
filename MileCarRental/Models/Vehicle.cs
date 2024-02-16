namespace MileCarRental.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        // Otros atributos como precio, disponibilidad, etc.
    }

}
