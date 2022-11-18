using BHD_HRM.Data.Employee;
using BHD_HRM.Data.Employees;
using BHD_HRM.Pages.Employee.ViewModel;
using BHD_HRM.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using MixERP.Net.VCards;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using QRCoder;
using System.DrawingCore;
using System.DrawingCore.Imaging;

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
        UrlDto urlDto;
        private bool value;
        protected override async Task OnInitializedAsync()
        {
            _spinnerService.Show();

            await Task.Delay(1000);

            _spinnerService.Hide();
            var user = (await authenticationStateTask).User;
            {
                _employeeDto = new List<EmployeeDto>();
                var getpendingemp = await BHD_HRMService.GetAllAsync("TblNhanViens");
                foreach (var item in getpendingemp)
                {
                    EmployeeDto employeeDto = new EmployeeDto();
                    employeeDto.employeeData = item;
                    employeeDto.NgaySinhDate = item.NgaySinh == null ? null: DateOnly.FromDateTime((DateTime)item.NgaySinh);
                    employeeDto.NgayCapDate = item.NgayCap == null ? null :DateOnly.FromDateTime( (DateTime)item.NgayCap);
                    _employeeDto.Add(employeeDto);
                    //update đồng loạt name card +vcard
                    //string fullName = item.HoTen;

                    //string[] arrayStr = fullName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    //string ho = arrayStr[0];
                    //string ten = arrayStr[arrayStr.Length - 1];

                    //StringBuilder midleName = new StringBuilder();
                    ////Lấy tên đệm
                    //for (int i = 1; i < arrayStr.Length - 1; i++)
                    //{
                    //    midleName.Append(arrayStr[i] + " ");
                    //}
                    //var vcard = new VCard
                    //{
                    //    Version = VCardVersion.V3,
                    //    FirstName = Utility.RemoveSign4VietnameseString(ho).ToUpper() + " " + Utility.RemoveSign4VietnameseString(midleName.ToString()).ToUpper(),
                    //    LastName = Utility.RemoveSign4VietnameseString(ten).ToUpper(),
                    //    FormattedName = Utility.RemoveSign4VietnameseString(item.HoTen).ToUpper(),
                    //    Organization = "BHD STAR CINEPLEX",
                    //    Addresses = new List<Address>
                    //{
                    //    new Address
                    //    {
                    //        Type = AddressType.Work,
                    //        PoBox = "",
                    //        ExtendedAddress = "",
                    //        Street = "159 Xa Lo Ha Noi",
                    //        Locality = "Thanh Pho Ho Chi Minh",
                    //        Region = "Quan 2",
                    //        PostalCode = "70000",
                    //        Country = "Viet Nam",
                    //        Label = "",
                    //        Preference = 1,
                    //        TimeZone = TimeZoneInfo.Local
                    //    }
                    //},
                    //    Telephones = new List<Telephone>
                    //{
                    //    new Telephone
                    //    {
                    //        Type = TelephoneType.Preferred,
                    //        Number = ""
                    //    },
                    //    new Telephone
                    //    {
                    //        Type = TelephoneType.Home,
                    //        Number = ""
                    //    },
                    //    new Telephone
                    //    {
                    //        Type = TelephoneType.Work,
                    //        Number = item.SoDt
                    //    },
                    //    new Telephone
                    //    {
                    //        Type = TelephoneType.Car,
                    //        Number = ""
                    //    },
                    //    new Telephone
                    //    {
                    //        Type = TelephoneType.Fax,
                    //        Number = ""
                    //    },
                    //    new Telephone
                    //    {
                    //        Type = TelephoneType.Cell,
                    //        Number = item.SoDt
                    //    }
                    //},
                    //    Emails = new List<Email>
                    //{
                    //    new Email
                    //    {
                    //        Type = EmailType.Smtp,
                    //        EmailAddress = item.Email
                    //    },
                    //},
                    //    Url = new Uri("https://bhdstar.vn")
                    //};
                    //string serialized = vcard.Serialize();
                    //var path = Path.Combine(Environment.ContentRootPath, "wwwroot", "usersupload/VCard/", item.CardNumber + ".vcf");
                    //File.WriteAllText(path, serialized);
                    //var pathImageQR = Path.Combine(Environment.ContentRootPath, "wwwroot", "usersupload/avatar/bhd.png");
                    //string imagePath = Path.Combine(Environment.ContentRootPath, "wwwroot", "usersupload/VCard/", item.CardNumber + ".png");
                    //QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    //QRCodeData qrCodeData = qrGenerator.CreateQrCode(serialized, QRCodeGenerator.ECCLevel.Q);
                    //QRCode qrCode = new QRCode(qrCodeData);
                    //Bitmap qrCodeImage = qrCode.GetGraphic(5, System.DrawingCore.Color.Black, System.DrawingCore.Color.White, (Bitmap)Bitmap.FromFile(pathImageQR));
                    //qrCodeImage.Save(imagePath, ImageFormat.Png);
                }
                _companyData = await BHD_HRMComapyService.GetAllAsync("TblCompanies");                
                _empPage.EmpDatas = _employeeDto;
            }            

        }
        private void ShowModal()
        {
            urlDto = new UrlDto();
            value = true;
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
            var path = Path.Combine(Environment.ContentRootPath, "wwwroot", "usersupload/VCard/", _emp.employeeData.CardNumber+".vcf");
            var pathQR = Path.Combine(Environment.ContentRootPath, "wwwroot", "usersupload/VCard/", _emp.employeeData.CardNumber+".png");
            string _content = "Dear " + _emp.employeeData.HoTen +".<br/>"+"<br/>" +
                             "Phòng HCNS BHD Star gửi bạn file VCard và mã QR NameCard"+"<br/>" +
                             "<img src=cid:MyImage  id='img' alt=''/>"
                             ;
            await MailService.SendEmailAsync(_emp.employeeData.Email, "Bhd Star gửi thông tin VCard", _content,path,pathQR);
        }          
        private void NavigateToCreate()
        {
            Nav.NavigateTo($"/employee/employeeedit");              
        }
        private async Task HandleOnSave(ModalActionEventArgs args)
        {
            try
            {
                // logic in real world here
                await Task.Delay(1000);
                urlDto.Url =MyNavigationManager.BaseUri+"employee/employeeaddbyusers/"+DateTime.Now.ToString("MMddyyHHmmssfff");
                urlDto.Status = true;
                await BHD_HRMUrlService.SaveAsync("TblUrls", urlDto);
                string _content = "Dear Anh/Chị ứng viên" + "<br/>" +"<br/>" +
                             "Phòng HCNS BHD Star gửi bạn Link đăng ký thông tin cá nhân:"+"<br/>" +
                             "<a href="+urlDto.Url+">Nhấp vào đây để đăng ký thông tin!</a>"+"<br/>" +"<br/>" +
                             "Vui lòng bổ sung thông tin trong vòng 24h.";
                await MailService.SendEmailAsync(urlDto.Email, "Bhd Star gửi Link đăng ký thông tin", _content, "","");
                value = false;
            }
            catch (Exception e)
            {
                args.Cancel();
            }
        }

        private void HandleOnCancel()
        {
            value = false;
        }
    }
}
