using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class Tuan
    {
        public Tuan()
        {
            Chuongs = new HashSet<Chuong>();
        }

        public int Id { get; set; }
        public int? Ten { get; set; }

        public virtual ICollection<Chuong> Chuongs { get; set; }
    }
}
