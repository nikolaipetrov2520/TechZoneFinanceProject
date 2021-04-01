using iTech.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace iTech.Model
{
    public class Type
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
