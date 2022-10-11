using BHD_HRM.Data.Employee;
using BHD_HRM.Data.Employees;
using BHD_HRM.Pages.Employee.ViewModel;
using BHD_HRM.Services;
using System.Diagnostics.CodeAnalysis;

namespace BHD_HRM.Pages.Employee
{
    public partial class Employees: ProCompontentBase
    {
        public bool _visible;
        public EmpPage? _empPage=new EmpPage();
        public List<EmployeeDto>? _employeeDto=new List<EmployeeDto>();
        public List<CompanyData> _companyData{ get; set; }
        protected override async Task OnInitializedAsync()
        {
            var getpendingemp = await BHD_HRMService.GetAllAsync("TblNhanViens");
            foreach(var item in getpendingemp)
            {
                EmployeeDto employeeDto = new EmployeeDto();
                employeeDto.employeeData = item;
                employeeDto.NgaySinhDate = DateOnly.FromDateTime((DateTime)item.NgaySinh);
                employeeDto.NgayCapDate = DateOnly.FromDateTime(item.NgayCap==null?DateTime.Now:(DateTime)item.NgayCap);
                _employeeDto.Add(employeeDto);
            }
            _companyData=await BHD_HRMComapyService.GetAllAsync("TblCompanies");
            _empPage.EmpDatas = _employeeDto;

        }
        private List<int> _pageSizes = new() { 10, 25, 50, 100 };
        private readonly List<DataTableHeader<EmployeeDto>> _headers = new()
        {
            new() { Text = "Họ Tên", Value = nameof(EmployeeDto.employeeData.HoTen), CellClass = "" },
            new() { Text = "Ngày sinh", Value = nameof(EmployeeDto.NgaySinhDate) },
            new() { Text = "Giới tính", Value = nameof(EmployeeDto.employeeData.GioiTinh) },
            new() { Text = "Số điện thoại", Value = nameof(EmployeeDto.employeeData.SoDt) },
            new() { Text = "Email", Value = nameof(UserDto.Email) },
            new() { Text = "ACTIONS", Value = "Action", Sortable = false }
        };
        private readonly Dictionary<string, string> _roleIconMap = UserServices.GetRoleIconMap();
        private void NavigateToDetails(string id)
        {
            Nav.NavigateTo($"/employee/employeeview/{id}");
        }

        private void NavigateToEdit(string id)
        {
            Nav.NavigateTo($"/employee/employeeedit/{id}");
        }

        private void AddUserData(EmployeeDto empData)
        {
            _empPage.EmpDatas.Insert(0, empData);
        }
    }
}
