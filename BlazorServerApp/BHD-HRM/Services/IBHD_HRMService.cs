using BHD_HRM.Data;
using BHD_HRM.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHD_HRM.Services
{
    public interface IBHD_HRMService<T>
    {
        Task<List<T>> GetAllAsync(string requestUri);

        Task<List<T>> GetbyConAsync(string requestUri, string Id);
        Task<T> GetByIdAsync(string requestUri, string Id);
        Task<T> SaveAsync(string requestUri, T obj);
        Task<T> UpdateAsync(string requestUri, string Id, T obj);
        Task<T> UpdatebyidAsync(string requestUri, int Id, T obj);

        Task<T> UpdatebyidstringAsync(string requestUri, string Id, T obj);
        Task<bool> DeleteAsync(string requestUri, string Id);
    }
}
