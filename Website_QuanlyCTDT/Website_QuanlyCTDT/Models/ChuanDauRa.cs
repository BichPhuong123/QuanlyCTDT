using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class ChuanDauRa
    {
        public int Id { get; set; }
        public string Mota { get; set; }
        public int? IdMuctieu { get; set; }
        public string MaMh { get; set; }

        public virtual MucTieu IdMuctieuNavigation { get; set; }
        public virtual MonHoc MaMhNavigation { get; set; }
    }
}
