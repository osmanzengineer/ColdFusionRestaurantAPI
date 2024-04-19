using System;

namespace Business.DTO.Order
{
    public class GetOrderRequest
    {
        public Guid CustomerID { get; set; }
        public bool IsChecked { get; set; }
    }
}
