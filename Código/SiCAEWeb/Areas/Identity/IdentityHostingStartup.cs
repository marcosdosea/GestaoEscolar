using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiCAEWeb.Areas.Identity.Data;

[assembly: HostingStartup(typeof(SiCAEWeb.Areas.Identity.IdentityHostingStartup))]
namespace SiCAEWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseMySQL(
                        context.Configuration.GetConnectionString("SiCAEConnection")));

                services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityContext>();
            });
        }
    }
}