using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class MonNganh
    {
        public string Manganh { get; set; }
        public string MaMh { get; set; }

        public virtual MonHoc MaMhNavigation { get; set; }
        public virtual Nganh ManganhNavigation { get; set; }
    }
}
