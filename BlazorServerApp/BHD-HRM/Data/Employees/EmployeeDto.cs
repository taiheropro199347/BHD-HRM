using BHD_HRM.Data.Employee;
using System.ComponentModel.DataAnnotations;

namespace BHD_HRM.Data.Employees
{
    public class EmployeeDto
    {
        public EmployeeData employeeData { get; set; } = new EmployeeData();
        [Required(ErrorMessage = "Bạn phải nhập ngày cấp")]
        public DateOnly? NgayCapDate { get; set; }= null;
        [Required(ErrorMessage = "Bạn phải nhập ngày sinh")]
        public DateOnly? NgaySinhDate { get; set; } = null;
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
