using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BHD_HRM.Data.Users
{
    public partial class User
    {
        public string userAd { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên đăng nhập")]
        public string pass { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string timeCreate { get; set; }
        public int? roles { get; set; }
        public string token { get; set; }
        public int? idGroup { get; set; }
        public int? cinemaId { get; set; }
        public object userNo { get; set; }
        public string ConfirmPassword { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
