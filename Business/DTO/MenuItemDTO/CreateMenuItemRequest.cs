using System;

namespace Business.DTO.Menu
{
    public class CreateMenuItemRequest
    {
        public DayOfWeek? DayOfWeek { get; set; }
        public Guid CategoryID { get; set; }
        public bool IsPermanent { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public bool GlutenFree { get; set; }
        public bool IsVegan { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
