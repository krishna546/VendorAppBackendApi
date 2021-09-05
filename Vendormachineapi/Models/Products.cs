using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Vendormachineapi.Models
{
    public partial class Products
    {
        public Products()
        {
            OrdersHistory = new HashSet<OrdersHistory>();
        }

        public int Id { get; set; }
        public int? Item { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }

        public virtual ICollection<OrdersHistory> OrdersHistory { get; set; }
    }
}
