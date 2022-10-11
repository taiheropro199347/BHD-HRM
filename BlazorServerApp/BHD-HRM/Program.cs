using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BHD_HRM.Data;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using BHD_HRM.Services;
using BHD_HRM.Handlers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Tewr.Blazor.FileReader;
using Microsoft.Extensions.FileProviders;
using BHD_HRM.Data.Employee;
using BHD_HRM.Data.Employees;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
var appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);
builder.Services.AddMasaBlazor(builder =>
{
    builder.Theme.Primary = "#4318FF";
    builder.Theme.Accent = "#4318FF";
}).AddI18nForServer("wwwroot/i18n");
builder.Services.AddHttpContextAccessor();
builder.Services.AddGlobalForServer();
builder.Services.AddTransient<ValidateHeaderHandler>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient<IUserService, UserService>();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddFileReaderService(o => o.UseWasmSharedBuffer = true);
builder.Services.AddHttpClient<IBHD_HRMService<EmployeeData>, BHD_HRMService<EmployeeData>>()
                   .AddHttpMessageHandler<ValidateHeaderHandler>();
builder.Services.AddHttpClient<IBHD_HRMService<CompanyData>, BHD_HRMService<CompanyData>>()
                   .AddHttpMessageHandler<ValidateHeaderHandler>();
builder.Services.AddHttpClient<IBHD_HRMService<DepartmentData>, BHD_HRMService<DepartmentData>>()
                   .AddHttpMessageHandler<ValidateHeaderHandler>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SeniorEmployee", policy =>
        policy.RequireClaim("IsUserEmployedBefore1990", "true"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
     app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
