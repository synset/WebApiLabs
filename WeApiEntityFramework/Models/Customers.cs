using System;
using System.Collections.Generic;

namespace WeApiEntityFramework.Models
{
    public partial class Customers
    {
        public Customers()
        {
            RentalOrders = new HashSet<RentalOrders>();
        }

        public int Id { get; set; }
        public int DriverLicenceNumber { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<RentalOrders> RentalOrders { get; set; }
    }
}
