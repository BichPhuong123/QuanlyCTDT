using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class PhanCongNha
    {
        public int Id { get; set; }
        public string Mota { get; set; }
        public int? IdChuong { get; set; }

        public virtual Chuong IdChuongNavigation { get; set; }
    }
}
