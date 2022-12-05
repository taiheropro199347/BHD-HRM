namespace BHD_HRM.Data.Employees
{
    public class CompanyDto
    {
        public CompanyData companyData { get; set; }
        public string AreaName => companyData.Area.Name;
    }
}
