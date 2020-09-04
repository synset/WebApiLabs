using System;
using System.Collections.Generic;

namespace WeApiEntityFramework.Models
{
    public partial class Employees
    {
        public Employees()
        {
            RentalOrders = new HashSet<RentalOrders>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<RentalOrders> RentalOrders { get; set; }
    }
}
