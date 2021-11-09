using System;
using System.Collections.Generic;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class MhtienQuyet
    {
        public string MaMh { get; set; }
        public string MaMhtq { get; set; }

        public virtual MonHoc MaMhNavigation { get; set; }
        public virtual MonHoc MaMhtqNavigation { get; set; }
    }
}
