// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BHDHRMWebAPI.Models
{
    public partial class Area
    {
        public Area()
        {
            TblCongTy = new HashSet<TblCongTy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public bool Isvisible { get; set; }

        public virtual ICollection<TblCongTy> TblCongTy { get; set; }
    }
}