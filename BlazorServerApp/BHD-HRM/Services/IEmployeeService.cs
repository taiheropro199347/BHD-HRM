using BHD_HRM.Data;
using BHD_HRM.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHD_HRM.Services
{
    public interface IEmployeeService
    {
        public Task<string> UploadEmployeeImage(MultipartFormDataContent content);
    }
}
