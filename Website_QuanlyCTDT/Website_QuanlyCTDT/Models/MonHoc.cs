using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            ChuanDauRas = new HashSet<ChuanDauRa>();
            Chuongs = new HashSet<Chuong>();
            MhtienQuyetMaMhNavigations = new HashSet<MhtienQuyet>();
            MhtienQuyetMaMhtqNavigations = new HashSet<MhtienQuyet>();
            MucTieus = new HashSet<MucTieu>();
        }

        public string MaMh { get; set; }
        public string Ten { get; set; }
        public int? Sotinchi { get; set; }
        public string Mota { get; set; }
        public int? IdChuyennganh { get; set; }

        public virtual ChuyenNganh IdChuyennganhNavigation { get; set; }
        public virtual ICollection<ChuanDauRa> ChuanDauRas { get; set; }
        public virtual ICollection<Chuong> Chuongs { get; set; }
        public virtual ICollection<MhtienQuyet> MhtienQuyetMaMhNavigations { get; set; }
        public virtual ICollection<MhtienQuyet> MhtienQuyetMaMhtqNavigations { get; set; }
        public virtual ICollection<MucTieu> MucTieus { get; set; }
    }
}
