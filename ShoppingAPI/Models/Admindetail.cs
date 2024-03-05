using System;
using System.Collections.Generic;

namespace ShoppingAPI.Models
{
    public partial class Admindetail
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? EmailId { get; set; }
        public string? MobileNumber { get; set; }
        public string? Password { get; set; }
    }
}
