
using Victoria.Plumbing.Data;
using Victoria.Plumbing.Models.DomainModels;
using Victoria.Plumbing.Models.Dto;
using VictoriaPlumbing.Core.Services.Interfaces;

namespace Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataDbContext _dbContext;

        public OrderService(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateOrder(OrderDto orderDto)
        {
            ValidateOrder(orderDto);

            var order = Orders.MapOrderDtoToEntity(orderDto);

            _dbContext.Orders.Add(order);
            _dbContext.SaveChangesAsync();
        }


        private void ValidateOrder(OrderDto orderDto)
        {
            NullOrderValidation(orderDto);
            OrderDateValidation(orderDto.OrderDate);
            OrderCostValidation(orderDto.OrderItems);
            OrderPriceValidation(orderDto);
        }

        private void OrderPriceValidation(OrderDto orderDto)
        {
            var orderItemProductIds = orderDto.OrderItems.Select(orderItem => orderItem.ProductId);
            var isMatchingCost = _dbContext.Products
                .Where(products => orderItemProductIds
                .Contains(products.Id) && orderDto.OrderItems
                .Any(orderItem =>
                          orderItem.ProductId == products.Id &&
                          orderItem.UnitPrice != products.Cost));


            if (!isMatchingCost.Any())
            {
                var mismatchingIds = isMatchingCost.Select(productId => productId.Id).ToList();
                throw new ArgumentException($"Product ID's:{mismatchingIds} from DTO does not match price in database");
            }
        }

        private static void OrderCostValidation(List<OrderItemDto> orderItems)
        {
            var totalCost = orderItems.Sum(itemDto => itemDto.UnitPrice * itemDto.Quantity);
            if (totalCost <= 0)
            {
                throw new ArgumentException("Total order cost must be greater than zero.");
            }
        }

        private static void OrderDateValidation(DateTime orderDate)
        {
            if (orderDate > DateTime.Now)
            {
                throw new ArgumentException("Order date cannot be in the future.", nameof(orderDate));
            }
        }

        private static void NullOrderValidation(OrderDto orderDto)
        {
            if (orderDto == null)
            {
                throw new ArgumentNullException(nameof(orderDto), "Order cannot be null.");
            }
        }


        //wp - this works without the private setters, if i had more time i could encapsulate business logicv with the models - DDD
        private static Orders MapOrderDtoToEntity(OrderDto orderDto)
        {
            var order = new Orders
            {
                Id = orderDto.OrderId,
                CustomerId = orderDto.CustomerId,
                OrderDate = DateTime.Now,
                OrderItem = orderDto.OrderItems.Select(itemDto => new OrderItem
                {

                    ProductId = itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    Product = new Product
                    {
                        Id = itemDto.ProductId,
                        Name = itemDto.ProductName,
                        Cost = itemDto.UnitPrice,
                    }
                }).ToList()
            };

            return order;
        }
    }
}
