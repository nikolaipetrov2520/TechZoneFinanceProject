using System;
using System.Collections.Generic;

#nullable disable

namespace iTech.Model
{
    public partial class Cost
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string Name { get; set; }

        public decimal? Sum { get; set; }
        
    }
}
