using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class ChuyenNganh
    {
        public ChuyenNganh()
        {
            MonHocs = new HashSet<MonHoc>();
        }

        public int Id { get; set; }
        public string TenCn { get; set; }

        public virtual ICollection<MonHoc> MonHocs { get; set; }
    }
}
