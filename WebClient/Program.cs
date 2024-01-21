﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using AspNetCore.ReCaptcha;
using BussinessObject;
using DataAccess.Authorize;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //CAPCHA
            builder.Services.AddReCaptcha(builder.Configuration.GetSection("ReCaptcha2"));

            //Author
            builder.Services.AddDbContext<Web_Trung_GianContext>(options => options.UseSqlServer("server=localhost;database=Web_Trung_Gian;uid=sa;pwd=123456;TrustServerCertificate=True;"));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Home/Login";
                options.AccessDeniedPath = "/Home/Index";
            });

            builder.Services.AddAuthorization();

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            builder.Services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}