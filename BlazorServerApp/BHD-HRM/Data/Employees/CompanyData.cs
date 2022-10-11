﻿namespace BHD_HRM.Data.Employees
{
    public class CompanyData
    {
        public int Id { get; set; }
        public string IdtapDoan { get; set; }
        public string TenCongTy { get; set; }
        public string DiaChi { get; set; }
        public string SoDt { get; set; }
        public string TinhTrang { get; set; }
        public int? AreaId { get; set; }
        public bool? HienThi { get; set; }

        public virtual AreaData Area { get; set; }
    }
}