using BHD_HRM.Data.Employees;
using BHD_HRM.Pages.Employee.ViewModel;


namespace BHD_HRM.Pages.Employee
{
    public partial class EmployeeList : ProCompontentBase
    {
        private object? _profitChart1;
        private object? _profitChart;
        private object? _profitChart2;
        public bool _visible;
        public EmpPage? _empPage = new EmpPage();
        public List<EmployeeDto>? _employeeDto = new List<EmployeeDto>();
        public List<CompanyData> _companyData { get; set; }
        public List<DepartmentData> _departmentData { get; set; }
        public List<int> _chart=new List<int>();
        public List<int> _chart1=new List<int>();
         public List<int> _chart2=new List<int>();
        protected override async Task OnInitializedAsync()
        {
            _spinnerService.Show();

            await Task.Delay(1000);

            _spinnerService.Hide();
            var getpendingemp = await BHD_HRMService.GetAllAsync("TblNhanViens/GetAvailNhanVien");
            foreach (var item in getpendingemp)
            {
                EmployeeDto employeeDto = new EmployeeDto();
                employeeDto.employeeData = item;
                employeeDto.NgaySinhDate = DateOnly.FromDateTime((DateTime)item.NgaySinh);
                employeeDto.NgayCapDate = DateOnly.FromDateTime(item.NgayCap == null ? DateTime.Now : (DateTime)item.NgayCap);
                _employeeDto.Add(employeeDto);
            }
            _companyData = await BHD_HRMComapyService.GetAllAsync("TblCompanies");
            if(_companyData!=null)
            {
                int i = 2;
                  List<Data> _itemdatas = new List<Data>();
                foreach(var item in _companyData)
                {
                    _departmentData =await BHD_HRMDepartmentService.GetbyConAsync("TblPhongs/GetDepmbyComp/", item.Id.ToString());
                     List<Data> _itemchills = new List<Data>();
                    if(_departmentData!=null)
                    {
                        foreach (var itemchill in _departmentData)
                        {
                            Data datachill = new Data();
                            datachill.Id = i;
                            datachill.IdString = itemchill.Id;
                            datachill.Name = itemchill.TenPhong;
                            datachill.Type = "Department";
                            _itemchills.Add(datachill);
                            i++;
                        }    
                    }    
                     Data _itemdata = new Data();
                    _itemdata.Id = i;
                    _itemdata.IdString = item.Id.ToString();
                    _itemdata.Name = item.TenCongTy;
                    _itemdata.Children = _itemchills;
                    _itemdatas.Add(_itemdata);
                    i++;

                }
                    Data _itemTreeView = new Data();
                _itemTreeView.Id = 1;
                _itemTreeView.Name = "BHDS Human Resources";
                    _itemTreeView.Children = _itemdatas;
                _items.Add(_itemTreeView);

            }
            _empPage.EmpDatas = _employeeDto;
            var StreetCrimes = _employeeDto
       .Where(x => x.employeeData.Id > 0 && x.employeeData.NgayVaoCongTy!=null)
       .GroupBy(s => new { month = ((DateTime)s.employeeData.NgayVaoCongTy).Month })
       .Select(x => new { count = x.Count()})
       .ToArray();
            foreach (var _item in StreetCrimes)
            {
                _chart.Add(_item.count);
            }
            var StreetCrimes1 = _employeeDto
       .Where(x => x.employeeData.Id > 0 && x.employeeData.NgayVaoCongTy != null && x.employeeData.TrangThai=="Full Time")
       .GroupBy(s => new { month = ((DateTime)s.employeeData.NgayVaoCongTy).Month })
       .Select(x => new { count = x.Count() })
       .ToArray();
            foreach (var _item in StreetCrimes1)
            {
                _chart1.Add(_item.count);
            }
            var StreetCrimes2 = _employeeDto
      .Where(x => x.employeeData.Id > 0 && x.employeeData.NgaySinh != null)
      .GroupBy(s => new { month = ((DateTime)s.employeeData.NgaySinh).Month })
      .Select(x => new { count = x.Count() })
      .ToArray();
            foreach (var _item in StreetCrimes2)
            {
                _chart2.Add(_item.count);
            }
            _profitChart = new
            {
                Tooltip = new
                {
                    Trigger = "axis",
                    axisPointer = new
                    {
                        Type = "shadow"
                    }
                },
                XAxis = new
                {
                    Data = new[] { "", "", "3", "", "", "6", "", "", "9", "", "", "12" },
                    axisLine = new
                    {
                        Show = false
                    },
                    axisLabel = new
                    {
                        Show = false
                    },
                    axisTick = new
                    {
                        Show = false
                    },
                    splitLine = new
                    {
                        Show = false
                    },
                },
                YAxis = new
                {
                    axisLine = new
                    {
                        Show = false
                    },
                    axisLabel = new
                    {
                        Show = false
                    },
                    axisTick = new
                    {
                        Show = false
                    },
                    splitLine = new
                    {
                        Show = false
                    },
                },
                Series = new[]
               {
                    new
                    {
                        Type= "bar",
                        Data= _chart,
                        Color= "#4318FF"
                    }
                },
                Grid = new
                {
                    x = 5,
                    x2 = 5,
                    y = 5,
                    y2 = 5
                }
            };
            _profitChart1 = new
            {
                Tooltip = new
                {
                    Trigger = "axis",
                    axisPointer = new
                    {
                        Type = "shadow"
                    }
                },
                XAxis = new
                {
                    Data = new[] { "", "", "3", "", "", "6", "", "", "9", "", "", "12" },
                    axisLine = new
                    {
                        Show = false
                    },
                    axisLabel = new
                    {
                        Show = false
                    },
                    axisTick = new
                    {
                        Show = false
                    },
                    splitLine = new
                    {
                        Show = false
                    },
                },
                YAxis = new
                {
                    axisLine = new
                    {
                        Show = false
                    },
                    axisLabel = new
                    {
                        Show = false
                    },
                    axisTick = new
                    {
                        Show = false
                    },
                    splitLine = new
                    {
                        Show = false
                    },
                },
                Series = new[]
                {
                    new
                    {
                        Type= "bar",
                        Data= _chart1,
                        Color= "#4318FF"
                    }
                },
                Grid = new
                {
                    x = 5,
                    x2 = 5,
                    y = 5,
                    y2 = 5
                }
            };
            _profitChart2 = new
            {
                Tooltip = new
                {
                    Trigger = "axis",
                    axisPointer = new
                    {
                        Type = "shadow"
                    }
                },
                XAxis = new
                {
                    Data = new[] { "", "", "3", "", "", "6", "", "", "9", "", "", "12" },
                    axisLine = new
                    {
                        Show = false
                    },
                    axisLabel = new
                    {
                        Show = false
                    },
                    axisTick = new
                    {
                        Show = false
                    },
                    splitLine = new
                    {
                        Show = false
                    },
                },
                YAxis = new
                {
                    axisLine = new
                    {
                        Show = false
                    },
                    axisLabel = new
                    {
                        Show = false
                    },
                    axisTick = new
                    {
                        Show = false
                    },
                    splitLine = new
                    {
                        Show = false
                    },
                },
                Series = new[]
                {
                    new
                    {
                        Type= "bar",
                        Data= _chart2,
                        Color= "#4318FF"
                    }
                },
                Grid = new
                {
                    x = 5,
                    x2 = 5,
                    y = 5,
                    y2 = 5
                }
            };
        }

        private List<int> _pageSizes = new() { 10, 25, 50, 100 };
        private readonly List<DataTableHeader<EmployeeDto>> _headers = new()
        {
            new() { Text = "Họ Tên", Value = nameof(EmployeeDto.HoTen), CellClass = "" },
            new() { Text = "Ngày sinh", Value = nameof(EmployeeDto.NgaySinhDate) },
            new() { Text = "Giới tính", Value = nameof(EmployeeDto.GioiTinh) },
            new() { Text = "Số điện thoại", Value = nameof(EmployeeDto.SoDt) },
            new() { Text = "Email", Value = nameof(EmployeeDto.Email) },
            new() { Text = "Trạng thái", Value = nameof(EmployeeDto.TrangThai) }
        };

        private void NavigateToDetails(string id)
        {
            Nav.NavigateTo($"/employee/employeeview/{id}");
        }
        public void UpdateGrid( List<Data> val)
        {
            List<string> department = new List<string>();
            if(val.First().Name=="BHDS Human Resources")
            {
                _empPage.EmpDatas = _employeeDto.ToList();
            }
            else
            {
                foreach(Data _itemcom in  val)
                {
                    if(_itemcom.Children!=null)
                    {
                        foreach (Data _itemdepart in _itemcom.Children)
                        {
                            department.Add(_itemdepart.IdString);
                        }
                    }
                    else
                    {
                        department.Add(_itemcom.IdString);
                    }    
                      
                }

                _empPage.EmpDatas = _employeeDto.Where(t => department.Contains(t.employeeData.IdphongBan)).ToList();
            }    

        }
        public class Data
        {
            public int Id { get; set; }
            public string IdString { get; set; }

            public string Name { get; set; }
            public string Type { get; set; }

            public List<Data> Children { get; set; }
        }

        private List<Data> _items = new List<Data>();
        private List<int> _open = new List<int>
        {
            1,
            2
        };
        private string _search;
        private bool _caseSensitive;

        public Func<Data, string, Func<Data, string>, bool> Filter
        {
            get
            {
                if (_caseSensitive)
                {
                    return (item, search, textKey) => textKey(item).IndexOf(search) > -1;
                }

                return null;
            }
        }
        private string GetEchartKey()
        {
            return GlobalConfig.NavigationMini.ToString() + MasaBlazor.Breakpoint.Width.ToString();
        }
    }
}
