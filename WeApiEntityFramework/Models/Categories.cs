using System;
using System.Collections.Generic;

namespace WeApiEntityFramework.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Cars = new HashSet<Cars>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public decimal? DailyRate { get; set; }
        public decimal? WeeklyRate { get; set; }
        public decimal? MonthlyRate { get; set; }
        public decimal? WeekendRate { get; set; }

        public virtual ICollection<Cars> Cars { get; set; }
    }
}
