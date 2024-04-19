using System;

namespace Business.DTO
{
    public class MenuItemResponse
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
