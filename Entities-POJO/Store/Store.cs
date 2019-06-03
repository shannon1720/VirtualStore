namespace Entities_POJO
{
    public class Store : BaseEntity
    {
        public string Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Category { get; set; }
        public decimal Earnings = 0;
        public bool Active { get; set; }
        public int? Cellar { get; set; }
    }
}