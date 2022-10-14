using BHD_HRM.Data.Employee;

namespace BHD_HRM.Data.Employees
{
    public class EmployeeDto
    {
        public EmployeeData employeeData { get; set; } = new EmployeeData();
        public DateOnly NgayCapDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly NgaySinhDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? NgayNghiViecDate { get; set; } = null;
        public DateOnly? NgayVaoCongTyDate { get; set; } = null;
        public DateOnly? NgayKyHDLDDate { get; set; } = null;
        public string CompanyString { get; set; }
        public string DepartmentString { get; set; }
        public string? SampleName
        {
            get
            {
                string s;
                try
                {
                     s= string.Join("", employeeData.HoTen.Split(' ').Select(n => n[0].ToString().ToUpper()));
                }
                catch
                {
                    return s=employeeData.HoTen;
                }
                return s;
            }
        }
    }

}
