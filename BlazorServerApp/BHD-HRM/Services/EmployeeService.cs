using BHD_HRM.Data;
using Microsoft.Extensions.Options;

namespace BHD_HRM.Services
{
    public class EmployeeService:IEmployeeService
{
        public HttpClient _httpClient { get; }
        public AppSettings _appSettings { get; }

        public EmployeeService(HttpClient httpClient, IOptions<AppSettings> appSettings)


        {
            _appSettings = appSettings.Value;

            httpClient.BaseAddress = new Uri(_appSettings.BHD_HRMBaseAddress);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "BlazorServer");

            _httpClient = httpClient;
        }
        public async Task<string> UploadEmployeeImage(MultipartFormDataContent content)
        {
            var postResult = await _httpClient.PostAsync("http://localhost:5000/api/upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = Path.Combine("http://localhost:5000/", postContent);
                return imgUrl;
            }
        }
    }
}
