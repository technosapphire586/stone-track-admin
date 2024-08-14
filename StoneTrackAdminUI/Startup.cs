using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoneTrackAdmin.Services;
using StoneTrackAdmin.Utilites;
using StoneTrackAdmin.Utlities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Models;

namespace StoneTrackApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddDbContext<DbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {
                option.LoginPath = "/Account/AdminLogin";
                option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });
            services.AddTransient<IDapper, Dapper_ORM>();
            services.AddTransient<ILogin, LoginService>();
            services.AddTransient<ICustomers, CustomerService>();
            services.AddTransient<IBasicUtility, BasicUtility>();
            services.AddTransient<IJsonResponseFromat, JsonResponseFromat>();
            services.AddTransient<IBasicUtility, BasicUtility>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<IVehicle, VehicleServices>();
            services.AddTransient<IMaterial, MaterialServices>();
            services.AddTransient<IUser, UserServices>();
            services.AddTransient<IExportUtility, ExportUtility>();
            services.AddTransient<IPrintService, PrintService>();
            services.AddControllersWithViews();

            var assload = new CustomAssemblyLoadContext();
            assload.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll"));
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            //services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=AdminLogin}/{id?}");
            });
        }
    }
}
