using AutoMapper;
using DB.Models;
using Logic.Repository;
using Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace PersonelWebSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PersonalWebSiteContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PersonalWebSite"))
            );

            var mvcviews = services.AddControllersWithViews();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #region Repositories
            services.AddScoped(typeof(ISocialMediaRepository), typeof(SocialMediaRepository));
            services.AddScoped(typeof(ISkillsRepository), typeof(SkillsRepository));
            services.AddScoped(typeof(ISkillCategoriesRepository), typeof(SkillCategoriesRepository));
            services.AddScoped(typeof(IReferenceRepository), typeof(ReferenceRepository));
            services.AddScoped(typeof(IProjectRepository), typeof(ProjectRepository));
            services.AddScoped(typeof(ICvRepository), typeof(CvRepository));
            services.AddScoped(typeof(ICareerRepository), typeof(CareerRepository));
            services.AddScoped(typeof(IHobbyRepository), typeof(HobbyRepository));
            services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
            services.AddScoped(typeof(IPersonRepository), typeof(PersonRepository));
            services.AddScoped(typeof(IAccomplishmentRepository), typeof(AccomplishmentRepository));
            services.AddScoped(typeof(IEducationRepository), typeof(EducationRepository));
            services.AddScoped(typeof(ILanguageRepository), typeof(LanguageRepository));
            services.AddScoped(typeof(ICertificateRepository), typeof(CertificateRepository));
            #endregion

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.IsEssential = true;
            });

#if DEBUG
            mvcviews.AddRazorRuntimeCompilation();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
