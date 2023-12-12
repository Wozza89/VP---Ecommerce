namespace Victoria.Plumbing.Models.DomainModels
{
    public class Orders
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderItem> OrderItem { get; set; }
    }
}
