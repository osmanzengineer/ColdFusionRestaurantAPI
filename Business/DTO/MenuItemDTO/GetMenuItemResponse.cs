using System;

namespace Business.DTO.Menu
{
    public class GetMenuItemResponse
    {
        public Guid ID { get; set; }
        public CategoryResponse Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsPermanent { get; set; }
        public bool IsActive { get; set; }
        public bool GlutenFree { get; set; }
        public bool IsVegan { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
