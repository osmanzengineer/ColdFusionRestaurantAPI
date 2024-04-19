using System;
using System.Text.Json.Serialization;

namespace Entity
{
    public class Order
    {
        public virtual Guid ID { get; set; }
        public virtual Guid CustomerID { get; set; }
        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        public virtual Guid MenuItemID { get; set; }
        [JsonIgnore]
        public virtual MenuItem MenuItem { get; set; }
        public virtual int Count { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual string OrderNote { get; set; }
        public virtual bool IsChecked { get; set; } = false;
    }
}
