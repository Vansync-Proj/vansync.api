namespace VanSync.Domain.Models
{
    public class UserModel
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string? NumberHouse { get; set; }
        public string? City { get; set; }
        public decimal AmountToPay { get; set; }
    }
}
