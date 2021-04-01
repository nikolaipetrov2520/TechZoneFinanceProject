using System;
using System.Collections.Generic;
using System.Text;

namespace iTech.Model
{
    public class EditIncomModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }       
        public string Article { get; set; }       
        public int Quantity { get; set; }
        public string Type { get; set; }
        public decimal? Price { get; set; }
        public decimal? Repair { get; set; }
    }
}
