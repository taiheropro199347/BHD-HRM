// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BHDHRMWebAPI.Models
{
    public partial class Logs
    {
        public int LogId { get; set; }
        public int? ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int? ActionType { get; set; }
        public DateTime? ActionDate { get; set; }
        public string ActionBy { get; set; }
        public string IpAdress { get; set; }

        public virtual Modules Module { get; set; }
    }
}