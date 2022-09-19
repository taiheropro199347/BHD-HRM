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
        public string UserAd { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? Roles { get; set; }
        public string Token { get; set; }
        public int? IdGroup { get; set; }
        public int? CinemaId { get; set; }
        public Group Group { get; set; }
        public string ConfirmPassword { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
