﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BHDHRMWebAPI.Models
{
    public partial class TblEmail
    {
        public int EmailServerSettingId { get; set; }
        public string MailSmtp { get; set; }
        public int? PortMailSmtp { get; set; }
        public string MailImap { get; set; }
        public int? PortMailImap { get; set; }
        public string MailAccount { get; set; }
        public string Password { get; set; }
        public string MailCc { get; set; }
        public string MailBcc { get; set; }
        public bool? Ssl { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}