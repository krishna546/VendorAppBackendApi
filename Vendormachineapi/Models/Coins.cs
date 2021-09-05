using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Vendormachineapi.Models
{
    public partial class Coins
    {
        public int Id { get; set; }
        public string CoinDescription { get; set; }
        public decimal? Coinvalue { get; set; }
    }
}
