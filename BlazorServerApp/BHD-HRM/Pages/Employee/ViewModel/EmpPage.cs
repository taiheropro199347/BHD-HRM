using BHD_HRM.Data.Employees;

namespace BHD_HRM.Pages.Employee.ViewModel
{
    public class EmpPage
    {
        public List<EmployeeDto>? EmpDatas { get; set; }

        public string? Search { get; set; }
        public string  Status{get;set;}
        public string Role {get;set;}
        public int CompanyID { get; set; } = 0;   
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public int PageCount => (int)Math.Ceiling(CurrentCount / (double)PageSize);

        public int CurrentCount => GetFilterDatas()!=null?GetFilterDatas().Count():0;

       

        private IEnumerable<EmployeeDto> GetFilterDatas()
        {
            IEnumerable<EmployeeDto>? datas = EmpDatas;
            if(EmpDatas!=null)
            {
                if (Search is not null)
                {
                    datas = datas.Where(d => d.employeeData.HoTen.Contains(Search, StringComparison.OrdinalIgnoreCase) || d.employeeData.Email?.Contains(Search, StringComparison.OrdinalIgnoreCase) == true);
                }
                if (datas.Count() < (PageIndex - 1) * PageSize) PageIndex = 1;
            }
            if (Status is not null)
            {
                datas = datas.Where(d => d.employeeData.TrangThai == Status);
            }
            if (Role is not null)
            {
                datas = datas.Where(d => d.employeeData.Role == Role);
            }
            if (CompanyID !=0)
            {
                datas = datas.Where(d => d.employeeData.IdcongTy == CompanyID);
            }
            return datas;
        }

        public List<EmployeeDto> GetPageDatas()
        {
            return GetFilterDatas() != null?GetFilterDatas().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList():new List<EmployeeDto>();
        }
    }
}
