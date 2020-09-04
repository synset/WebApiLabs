using System;
using System.Collections.Generic;

namespace WeApiEntityFramework.Models
{
    public partial class Cars
    {
        public Cars()
        {
            RentalOrders = new HashSet<RentalOrders>();
        }

        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime? CarYear { get; set; }
        public string CategoryId { get; set; }
        public int? Doors { get; set; }
        public byte[] Picture { get; set; }
        public string Condition { get; set; }
        public string Available { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<RentalOrders> RentalOrders { get; set; }
    }
}
