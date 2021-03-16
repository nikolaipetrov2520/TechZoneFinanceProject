using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase.Model
{
    public partial class Cost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Sum { get; set; }
        public DateTime? Date { get; set; }
    }
}
