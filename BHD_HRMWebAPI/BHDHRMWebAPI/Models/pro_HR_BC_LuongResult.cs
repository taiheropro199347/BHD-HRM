﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHDHRMWebAPI.Models
{
    public partial class pro_HR_BC_LuongResult
    {
        public string CardNumber { get; set; }
        public string HoTen { get; set; }
        public string TenCongTy { get; set; }
        public string TenPhong { get; set; }
        public string ChucVu { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public int? LuongCB { get; set; }
        public string LyDo { get; set; }
    }
}