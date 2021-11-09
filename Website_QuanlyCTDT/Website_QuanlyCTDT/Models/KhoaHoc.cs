using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class KhoaHoc
    {
        public KhoaHoc()
        {
            MonKhoas = new HashSet<MonKhoa>();
        }

        public int Id { get; set; }
        public string TenKh { get; set; }

        public virtual ICollection<MonKhoa> MonKhoas { get; set; }
    }
}
