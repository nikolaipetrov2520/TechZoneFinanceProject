using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase.Model
{
    public partial class Cash2
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Money { get; set; }
    }
}
