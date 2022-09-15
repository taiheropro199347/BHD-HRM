﻿using System;
using System.Collections.Generic;

namespace BHDHRMWebAPI.Models
{
    public partial class RefreshToken
    {
        public int TokenId { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual BhdAccount User { get; set; }
    }
}