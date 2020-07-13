using DB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(PersonalWebSite.Areas.Identity.IdentityHostingStartup))]
namespace PersonalWebSite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<PersonalWebSiteContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PersonalWebSite")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PersonalWebSiteContext>();
            });
        }
    }
}