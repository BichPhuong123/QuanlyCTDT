using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class MonKhoa
    {
        public string MaMh { get; set; }
        public int IdKhoahoc { get; set; }
        public string Manganh { get; set; }

        public virtual KhoaHoc IdKhoahocNavigation { get; set; }
        public virtual Nganh ManganhNavigation { get; set; }
    }
}
