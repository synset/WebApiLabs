using System;
using System.Collections.Generic;

namespace WeApiEntityFramework.Models
{
    public partial class RentalOrders
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public string CarId { get; set; }
        public int? TankLevel { get; set; }
        public int? KilometersStart { get; set; }
        public int? KilometersEnd { get; set; }
        public int? TotalKilometers { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TotalDays { get; set; }
        public decimal? RateApplied { get; set; }
        public decimal? TaxRate { get; set; }
        public string OrderStatus { get; set; }
        public string Notes { get; set; }

        public virtual Cars Car { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Employees Employee { get; set; }
    }
}
