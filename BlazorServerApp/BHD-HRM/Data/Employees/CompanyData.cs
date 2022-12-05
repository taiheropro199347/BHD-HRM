namespace BHD_HRM.Data.Employees
{
    public class CompanyData
    {
        public int Id { get; set; }
        public string IdtapDoan { get; set; } = "BHD";
        public string TenCongTy { get; set; }
        public string DiaChi { get; set; }
        public string SoDt { get; set; }
        public string TinhTrang { get; set; }
        public int? AreaId { get; set; }
        public bool HienThi { get; set; }
        public int? SapXep { get; set; }
        public virtual AreaData Area { get; set; }
        public string AreaName => Area!=null?Area.Name:"";
    }
}
