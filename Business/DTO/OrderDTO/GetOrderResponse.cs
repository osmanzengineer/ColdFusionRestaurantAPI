using System;

namespace Business.DTO.Order
{
    public class GetOrderResponse
    {
        public CustomerResponse Customer { get; set; }
        public MenuItemResponse Menu { get; set; }
        public int Count { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNote { get; set; }
        public bool IsChecked { get; set; }
    }
}
