using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase.Model
{
    public partial class Income
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string Article { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Repair { get; set; }
    }
}
