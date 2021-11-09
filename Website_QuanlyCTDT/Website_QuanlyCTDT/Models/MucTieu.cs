using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class MucTieu
    {
        public MucTieu()
        {
            ChuanDauRas = new HashSet<ChuanDauRa>();
        }

        public int Id { get; set; }
        public string Mota { get; set; }
        public string MaMh { get; set; }

        public virtual MonHoc MaMhNavigation { get; set; }
        public virtual ICollection<ChuanDauRa> ChuanDauRas { get; set; }
    }
}
