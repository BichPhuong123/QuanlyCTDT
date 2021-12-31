using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class Chuong
    {
        public Chuong()
        {
            PhanCongLops = new HashSet<PhanCongLop>();
            PhanCongNhas = new HashSet<PhanCongNha>();
        }

        public int Id { get; set; }
        public string Ten { get; set; }
        public int? IdTuan { get; set; }
        public string MaMh { get; set; }

        public virtual Tuan IdTuanNavigation { get; set; }
        public virtual MonHoc MaMhNavigation { get; set; }
        public virtual ICollection<PhanCongLop> PhanCongLops { get; set; }
        public virtual ICollection<PhanCongNha> PhanCongNhas { get; set; }
    }
}
