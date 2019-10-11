using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestCreator.Models;

[assembly: HostingStartup(typeof(TestCreator.Areas.Identity.IdentityHostingStartup))]
namespace TestCreator.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestCreatorContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestCreatorContextConnection")));

                //services.AddDefaultIdentity<IdentityUser>()
                //    .AddEntityFrameworkStores<TestCreatorContext>();
            });
        }
    }
}