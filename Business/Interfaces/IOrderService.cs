using Business.DTO.Order;
using System.Collections.Generic;

namespace Abstract
{
    public interface IOrderService
    {
        void CreateOrder(CreateOrderRequest orderRequest);
        List<GetOrderResponse> GetOrder(GetOrderRequest getOrderRequest);
    }
}
