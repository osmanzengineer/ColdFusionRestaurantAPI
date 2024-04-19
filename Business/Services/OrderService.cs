using Abstract;
using Business.DTO;
using Business.DTO.Order;
using Entity;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Business.Service
{
    public class OrderService : IOrderService
    {
        private readonly Context _context;
        public OrderService(Context context)
        {
            _context = context;
        }
        public void CreateOrder(CreateOrderRequest orderRequest)
        {
            try
            {
                List<Order> newOrderList = new List<Order>();
                foreach (var item in orderRequest.Orders)
                {

                    // Siparişi veritabanına ekle
                    Order newOrder = new Order
                    {
                        CustomerID = orderRequest.CustomerID,
                        MenuItemID = item.MenuItemID,
                        Count = item.Count,
                        OrderDate = DateTime.UtcNow,
                        OrderNote = orderRequest.OrderNote
                    };
                    newOrderList.Add(newOrder);
                }
                _context.AddRange(newOrderList);
                _context.SaveChanges();
                Console.WriteLine("Sipariş başarıyla oluşturuldu!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sipariş oluşturulurken bir hata oluştu: " + ex.Message);
            }
        }
        public List<GetOrderResponse> GetOrder(GetOrderRequest getOrderRequest)
        {
            return _context.Set<Order>()
                .Where(x => x.IsChecked == getOrderRequest.IsChecked && x.CustomerID == getOrderRequest.CustomerID)
                .Select(x => new GetOrderResponse
                {
                    Customer = new CustomerResponse
                    {
                        ID = x.Customer.ID,
                        Description = x.Customer.Description
                    },
                    Menu = new MenuItemResponse
                    {
                        ID = x.MenuItem.ID,
                        Name = x.MenuItem.Name,
                        Price = x.MenuItem.Price
                    },
                    Count = x.Count,
                    IsChecked = x.IsChecked,
                    OrderNote = x.OrderNote,
                    OrderDate = DateTime.Now
                }).ToList();
        }
    }
}
