﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Vendormachineapi.Models
{
    public partial class OrdersHistory
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Products Product { get; set; }
    }
}
