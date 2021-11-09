using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class Nganh
    {
        public Nganh()
        {
            MonNganhs = new HashSet<MonNganh>();
        }

        public string Manganh { get; set; }
        public string Tennganh { get; set; }

        public virtual ICollection<MonNganh> MonNganhs { get; set; }
    }
}
