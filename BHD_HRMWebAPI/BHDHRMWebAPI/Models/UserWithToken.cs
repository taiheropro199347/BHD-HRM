using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHDHRMWebAPI.Models
{
    public class UserWithToken : BhdAccount
    {
        
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithToken(BhdAccount user)
        {
            this.UserAd = user.UserAd;
            this.Email = user.Email;            
            this.Name = user.Name;
            this.IdGroup = user.IdGroup;
            this.Roles = user.Roles;
            this.CinemaId = user.CinemaId;
            this.Phone = user.Phone;
            this.IdGroupNavigation = user.IdGroupNavigation;
        }
    }
}
