using BHD_HRM.Data.Employee;
using BHD_HRM.Data.Employees;
using BHD_HRM.Pages.Employee.ViewModel;
using BHD_HRM.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics.CodeAnalysis;

namespace BHD_HRM.Pages.Employee
{
    public partial class Employees: ProCompontentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }
        public bool _visible;
        public EmpPage? _empPage=new EmpPage();
        public List<EmployeeDto>? _employeeDto=new List<EmployeeDto>();
        public List<CompanyData> _companyData{ get; set; }
        protected override async Task OnInitializedAsync()
        {
            var user = (await authenticationStateTask).User;
            {
                var getpendingemp = await BHD_HRMService.GetAllAsync("TblNhanViens");
                foreach (var item in getpendingemp)
                {
                    EmployeeDto employeeDto = new EmployeeDto();
                    employeeDto.employeeData = item;
                    employeeDto.NgaySinhDate = DateOnly.FromDateTime((DateTime)item.NgaySinh);
                    employeeDto.NgayCapDate = DateOnly.FromDateTime(item.NgayCap == null ? DateTime.Now : (DateTime)item.NgayCap);
                    _employeeDto.Add(employeeDto);
                }
                _companyData = await BHD_HRMComapyService.GetAllAsync("TblCompanies");
                _empPage.EmpDatas = _employeeDto;
            }            

        }
        private List<int> _pageSizes = new() { 10, 25, 50, 100 };
        private readonly List<DataTableHeader<EmployeeDto>> _headers = new()
        {
            new() { Text = "Họ Tên", Value = nameof(EmployeeDto.HoTen), CellClass = "" },
            new() { Text = "Ngày sinh", Value = nameof(EmployeeDto.NgaySinhDate) },
            new() { Text = "Giới tính", Value = nameof(EmployeeDto.GioiTinh) },
            new() { Text = "Số điện thoại", Value = nameof(EmployeeDto.SoDt) },
            new() { Text = "Email", Value = nameof(EmployeeDto.Email) },
            new() { Text = "ACTIONS", Value = "Action", Sortable = false }
        };
        private void NavigateToDetails(string id)
        {
            Nav.NavigateTo($"/employee/employeeview/{id}");
        }

        private void NavigateToEdit(string id)
        {
            Nav.NavigateTo($"/employee/employeeedit/{id}");
        }
        public async Task SentMailClick(string id)
        { 
            int _id = int.Parse(id); 
            var _emp = _employeeDto.Where(t => t.employeeData.Id == _id).FirstOrDefault();
            var path = Path.Combine(Environment.ContentRootPath, "wwwroot", "usersupload/VCard/", _emp.employeeData.CardNumber+"-"+_emp.employeeData.HoTen+".vcf");
            string _content = "Dear " + _emp.employeeData.HoTen +"<br/>"+
                             "Phòng HCNS BHD Star gửi bạn file VCard";
            await MailService.SendEmailAsync(_emp.employeeData.Email, "Bhd Star gửi thông tin VCard", _content,path);
        }
        private void NavigateToCreate()
        {
            Nav.NavigateTo($"/employee/employeeedit");
        }
    }
}
