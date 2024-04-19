using System;
using System.Collections.Generic;

namespace Business.DTO.Order
{
    public class CreateOrderRequest
    {
        public Guid CustomerID { get; set; }
        public List<MenuOrder> Orders { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNote { get; set; }
        public bool IsChecked { get; set; } = false;
    }

    public class MenuOrder
    {
        public Guid MenuItemID { get; set; }
        public int Count { get; set; }
    }
}
