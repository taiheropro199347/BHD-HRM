using BHD_HRM.Pages.App.User;

namespace BHD_HRM.Pages.Employee
{
    public partial class EmployeeList : ProCompontentBase
    {
        private object? _orderChart;
        private object? _profitChart;
        private object? _earningsChart;
        protected override void OnInitialized()
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
        }
        public bool _visible;
        public UserPage _userPage = new(UserServices.GetList());
        private List<int> _pageSizes = new() { 10, 25, 50, 100 };
        private readonly List<DataTableHeader<UserDto>> _headers = new()
        {
            new() { Text = "USER", Value = nameof(UserDto.UserName), CellClass = "" },
            new() { Text = "EMAIL", Value = nameof(UserDto.Email) },
            new() { Text = "ROLE", Value = nameof(UserDto.Role) },
            new() { Text = "PLAN", Value = nameof(UserDto.Plan) },
            new() { Text = "STATUS", Value = nameof(UserDto.Status) },
            new() { Text = "ACTIONS", Value = "Action", Sortable = false }
        };
        private readonly Dictionary<string, string> _roleIconMap = UserServices.GetRoleIconMap();

        private void NavigateToDetails(string id)
        {
            Nav.NavigateTo($"/app/user/view/{id}");
        }

        private void NavigateToEdit(string id)
        {
            Nav.NavigateTo($"/app/user/edit/{id}");
        }

        private void AddUserData(UserDto userData)
        {
            _userPage.UserDatas.Insert(0, userData);
        }
        public class Data
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public List<Data> Children { get; set; }
        }

        private List<Data> _items = new List<Data>()
        {
           new Data()
           {
              Id= 1,
              Name= "MASA Blazor Human Resources",
              Children= new List<Data>()
              {
                new Data()
                {
                  Id= 2,
                  Name= "Core team",
                  Children= new List<Data>()
                    {
                       new Data() {
                          Id= 201,
                          Name= "John",
                        },
                        new Data(){
                          Id= 202,
                          Name= "Kael",
                        },
                        new Data(){
                          Id= 203,
                          Name= "Nekosaur",
                        },
                        new Data(){
                          Id= 204,
                          Name= "Jacek",
                        },
                        new Data(){
                          Id= 205,
                          Name= "Andrew",
                        }
                    }
                },
                new Data()
                {
                  Id= 3,
                  Name= "Administrators",
                  Children= new List<Data>()
                    {
                        new Data()
                        {
                          Id= 301,
                          Name= "Mike",
                        },
                        new Data()
                        {
                          Id= 302,
                          Name= "Hunt",
                        }
                    }
                },
                new Data()
                {
                  Id= 4,
                  Name= "Contributors",
                  Children= new List<Data>()
                    {
                        new Data()
                        {
                          Id= 401,
                          Name= "Phlow"
                        },
                        new Data()
                        {
                          Id= 402,
                          Name= "Brandon"
                        },
                        new Data()
                        {
                          Id= 403,
                          Name= "Sean"
                        }
                    }
                },
                 new Data()
                {
                  Id= 5,
                  Name= "Contributors",
                  Children= new List<Data>()
                    {
                        new Data()
                        {
                          Id= 401,
                          Name= "Phlow"
                        },
                        new Data()
                        {
                          Id= 402,
                          Name= "Brandon"
                        },
                        new Data()
                        {
                          Id= 403,
                          Name= "Sean"
                        }
                    }
                },
                 new Data()
                {
                  Id= 6,
                  Name= "Contributors",
                  Children= new List<Data>()
                    {
                        new Data()
                        {
                          Id= 401,
                          Name= "Phlow"
                        },
                        new Data()
                        {
                          Id= 402,
                          Name= "Brandon"
                        },
                        new Data()
                        {
                          Id= 403,
                          Name= "Sean"
                        }
                    }
                }
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
