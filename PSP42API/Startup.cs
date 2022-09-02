using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BusinessService.Interface;
using BusinessService.Logic;
using DATA.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BusinessEntities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DAL;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace PSP42API
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDBContext>(ServiceLifetime.Transient);
            // configure strongly typed settings objects  
            var appSettingsSection = Configuration.GetSection("Jwt");
            //services.Configure<ServiceConfiguration>(appSettingsSection);
            //services.AddTransient<Services.IIdentityService, Services.IdentityService>();
            //services.AddTransient<Services.IUserService, Services.UserService>();

            // configure jwt authentication  
            var JwtSecretkey = Encoding.ASCII.GetBytes(Configuration["ServiceConfiguration:JwtSettings:Secret"]);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(JwtSecretkey),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true
            };
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ILogin, LoginService>();
            services.AddSingleton<IMenuBusiness, MenuBusinessService>();
            services.AddSingleton<DataLayer>();
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
             );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
           

            //app.UseApplicationInsightsRequestTelemetry();
            app.UseCors("CorsPolicy");


            //app.UseApplicationInsightsExceptionTelemetry();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

        }
    }
}
