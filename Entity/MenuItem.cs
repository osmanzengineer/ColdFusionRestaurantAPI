using System;
using System.Text.Json.Serialization;

namespace Entity
{
    public class MenuItem
    {
        public virtual Guid ID { get; set; }
        public virtual Guid CategoryID { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Price { get; set; }
        public virtual bool IsPermanent { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool GlutenFree { get; set; }
        public virtual bool IsVegan { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DayOfWeek? DayOfWeek { get; set; }
    }
}
