namespace BHD_HRM.Data.Employees
{
    public class DepartmentData
    {
        public string Id { get; set; }
       public int IdcongTy { get; set; }
       public string TenPhong { get; set; }
       public string GhiChu { get; set; }
       public virtual CompanyData TblCongTy { get; set; }
        public string CompanyName => TblCongTy != null ? TblCongTy.TenCongTy : "";
    }
}
