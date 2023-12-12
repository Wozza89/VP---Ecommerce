using Victoria.Plumbing.Models.Dto;

namespace VictoriaPlumbing.Core.Services.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(OrderDto orderDto);
    }
}
