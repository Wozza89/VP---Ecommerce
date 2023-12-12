using System.ComponentModel.DataAnnotations;

namespace Victoria.Plumbing.Models.Dto
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; } 
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
