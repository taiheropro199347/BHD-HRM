namespace BHD_HRM.Data.Employees
{
    public class AreaData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public bool Isvisible { get; set; }

        public virtual ICollection<CompanyData> CompanyData { get; set; }
    }
}
