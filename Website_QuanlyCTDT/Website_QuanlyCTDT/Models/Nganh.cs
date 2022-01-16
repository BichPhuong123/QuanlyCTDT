using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class Nganh
    {
        public Nganh()
        {
            MonKhoas = new HashSet<MonKhoa>();
        }

        public string Manganh { get; set; }
        public string Tennganh { get; set; }

        public virtual ICollection<MonKhoa> MonKhoas { get; set; }
    }
}
