namespace HappyRentals.WebApi.Data.Entities
{
    public class Home
    {
        public int HomeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public int HomeOwnerId { get; set; }
    }
}