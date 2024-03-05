using System;
using System.Collections.Generic;

namespace ShoppingAPI.Models
{
    public partial class Productdetail
    {
        public long Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        public decimal? Mrpprice { get; set; }
        public decimal? SellingPrice { get; set; }
        public string? Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
