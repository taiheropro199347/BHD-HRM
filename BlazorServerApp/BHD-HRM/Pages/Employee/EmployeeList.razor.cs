using BHD_HRM.Data.Employees;
using BHD_HRM.Pages.App.User;
using BHD_HRM.Pages.Employee.ViewModel;

namespace BHD_HRM.Pages.Employee
{
    public partial class EmployeeList : ProCompontentBase
    {
        private object? _orderChart;
        private object? _profitChart;
        private object? _earningsChart;
        public bool _visible;
        public EmpPage? _empPage = new EmpPage();
        public List<EmployeeDto>? _employeeDto = new List<EmployeeDto>();
        public List<CompanyData> _companyData { get; set; }
        public List<DepartmentData> _departmentData { get; set; }
        private List<Data> _items = new List<Data>();
        protected override async Task OnInitializedAsync()
        {

            _orderChart = new
            {
                Tooltip = new
                {
                    Trigger = "axis"
                },
                XAxis = new
                {
                    axisLine = new
                    {
                        Show = false
                    },
                    splitLine = new
                    {
                        Show = true,
                        LineStyle = new
                        {
                            Color = new[] { "#F0F3FA" }
                        }
                    },
                    axisLabel = new
                    {
                        Show = false
                    },
                    axisTick = new
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
                        name= "series-1",
                        Type= "line",
                        Data= ECommerceService.GetOrderChartData(),
                        Color= "#4318FF",
                        SymbolSize= 6,
                        Symbol= "circle",
                    }
                },
                Grid = new
                {
                    x = 3,
                    x2 = 3,
                    y = 3,
                    y2 = 3
                }
            };

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
                    Data = new[] { "", "", "", "", "" },
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
                        Data= ECommerceService.GetProfitChartData(),
                        Color= "#4318FF"
                    }
                },
                Grid = new
                {
                    x = 3,
                    x2 = 3,
                    y = 3,
                    y2 = 3
                }
            };

            int[] _earningsChartData = ECommerceService.GetEarningsChartData();

            _earningsChart = new
            {
                Tooltip = new
                {
                    Trigger = "item",
                },
                Series = new[]
                {
                   new
                   {
                       Type= "pie",
                       Radius= "90%",
                       Label=new
                       {
                           Show=false
                       },
                       Data=new[]
                       {
                           new
                           {
                               value= _earningsChartData[0],
                               Name= "Product",
                               ItemStyle=new
                               {
                                    Color= "#4318FF"
                               }
                           },
                           new
                           {
                               value= _earningsChartData[1],
                               Name= "App",
                               ItemStyle=new
                               {
                                    Color= "#05CD99"
                               }
                           },
                           new
                           {
                               value= _earningsChartData[2],
                               Name= "Service",
                               ItemStyle = new
                               {
                                    Color= "#FFB547"
                               }
                           },
                       }
                   }
                }
            };
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
            if(_companyData!=null)
            {
                foreach(var item in _companyData)
                {
                    _departmentData =await BHD_HRMDepartmentService.GetbyConAsync("TblPhongs/GetDepmbyComp/", item.Id.ToString());
                     List<Data> _itemchills = new List<Data>();
                    if(_departmentData!=null)
                    {
                        foreach (var itemchill in _departmentData)
                        {
                            Data datachill = new Data();
                            datachill.IdString = itemchill.Id;
                        }    
                    }    
                }    

            }
            _empPage.EmpDatas = _employeeDto;
        }
        public UserPage _userPage = new(UserServices.GetList());
        private List<int> _pageSizes = new() { 10, 25, 50, 100 };
        private readonly List<DataTableHeader<EmployeeDto>> _headers = new()
        {
            new() { Text = "Họ Tên",Sortable= false, Value = nameof(EmployeeDto.employeeData.HoTen), CellClass = "" },
            new() { Text = "Ngày sinh",Sortable= false, Value = nameof(EmployeeDto.NgaySinhDate) },
            new() { Text = "Giới tính",Sortable= false, Value = nameof(EmployeeDto.employeeData.GioiTinh) },
            new() { Text = "Số điện thoại",Sortable= false, Value = nameof(EmployeeDto.employeeData.SoDt) },
            new() { Text = "Email",Sortable= false, Value = nameof(EmployeeDto.employeeData.Email) }
        };

        private void NavigateToDetails(string id)
        {
            Nav.NavigateTo($"/app/user/view/{id}");
        }
        public class Data
        {
            public int Id { get; set; }
            public string IdString { get; set; }

            public string Name { get; set; }
            public string Type { get; set; }

            public List<Data> Children { get; set; }
        }

        private List<Data> _items = new List<Data>()
        {
           new Data()
           {
              Id= 1,
              Name= "BHDS Human Resources",
              Children= new List<Data>()
              {
                
              }
            }
        };
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
