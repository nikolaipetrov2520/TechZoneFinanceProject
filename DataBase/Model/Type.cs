using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase.Model
{
    public partial class Type
    {
        public Type()
        {
            Incomes = new HashSet<Income>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
    }
}
