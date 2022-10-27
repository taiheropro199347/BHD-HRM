using BHD_HRM.Data.Employee;
using System.ComponentModel.DataAnnotations;

namespace BHD_HRM.Data.Employees
{
    public class EmployeeDto
    {
        [EnumerableValidation]
        public EmployeeData employeeData { get; set; } = new EmployeeData();
        public DateOnly? NgayCapDate { get; set; }= null;
        public DateOnly? NgaySinhDate { get; set; } = null;
        public DateOnly? NgayNghiViecDate { get; set; } = null;
        public DateOnly? NgayVaoCongTyDate { get; set; } = null;
        public DateOnly? NgayKyHDLDDate { get; set; } = null;
        public string? HoTen { get { return employeeData.HoTen; }}
        public string? GioiTinh { get { return employeeData.GioiTinh; }}
        public string? SoDt { get { return employeeData.SoDt; }}
        public string? Email { get { return employeeData.Email; }}
         public string? TrangThai { get { return employeeData.TrangThai; }}
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
