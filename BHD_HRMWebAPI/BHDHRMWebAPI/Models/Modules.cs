// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BHDHRMWebAPI.Models
{
    public partial class Modules
    {
        public Modules()
        {
            BhdRoles = new HashSet<BhdRoles>();
            Logs = new HashSet<Logs>();
        }

        public int ModuleId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string ModuleUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public bool? Visible { get; set; }
        public int? DisplayOrder { get; set; }
        public string Image { get; set; }

        public virtual ICollection<BhdRoles> BhdRoles { get; set; }
        public virtual ICollection<Logs> Logs { get; set; }
    }
}