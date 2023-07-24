using Employee_Api_Jwt_1030.Models.Identity;
using Employee_Api_Jwt_1030.Service;
using Employee_Api_Jwt_1030.ServiceContract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Api_Jwt_1030
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
      string cs = Configuration.GetConnectionString("Constr");
      services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationDbcontext>
       (option => option.UseSqlServer(cs, b =>
        b.MigrationsAssembly("Employee_Api_Jwt_1030")));

      services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
      services.AddTransient<UserManager<ApplicationUser>, ApplicationUserManager>();
      services.AddTransient<SignInManager<ApplicationUser>, ApplicationSignInManager>();
      services.AddTransient<RoleManager<ApplicationRole>, ApplicationRoleManager>();
      services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
      services.AddTransient<IUserServices, UserService>();
      services.AddIdentity<ApplicationUser, ApplicationRole>()
      .AddEntityFrameworkStores<ApplicationDbcontext>()
      .AddUserStore<ApplicationUserStore>()
      .AddUserManager<ApplicationUserManager>()
      .AddRoleManager<ApplicationRoleManager>()
      .AddSignInManager<ApplicationSignInManager>()
      .AddRoleStore<ApplicationRoleStore>()
      .AddDefaultTokenProviders();

      services.AddScoped<ApplicationRoleStore>();
      services.AddScoped<ApplicationUserStore>();
      services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOption>();

      //JWt Authentication
      var AppSettingSection = Configuration.GetSection("AppSetting");
      services.Configure<AppSetting>(AppSettingSection);
      var AppSetting = AppSettingSection.Get<AppSetting>();
      var Key = Encoding.ASCII.GetBytes(AppSetting.Secret);
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

      }).AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters()
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Key),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });
      services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee_Api_Jwt_1030", Version = "v1" });
            });
      //cors
      //Cors
      services.AddCors(options =>
      {
        options.AddPolicy(name: "MyPolicy",
          builder =>
          {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
          });
      });
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee_Api_Jwt_1030 v1"));
            }
      app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
      app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();
      //Data
      //IServiceScopeFactory serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
      //using (IServiceScope scope = serviceScopeFactory.CreateScope())
      //{
      //  var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
      //  var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
      //  //Create Role Admin
      //  if (!await roleManager.RoleExistsAsync("Admin"))
      //  {
      //    var role = new ApplicationRole();
      //    role.Name = "Admin";
      //    await roleManager.CreateAsync(role);
      //  }
      //  //Create Role Employee
      //  if (!await roleManager.RoleExistsAsync("Employee"))
      //  {
      //    var role = new ApplicationRole();
      //    role.Name = "Employee";
      //    await roleManager.CreateAsync(role);
      //  }
      //  //Create Admin User
      //  if (await userManager.FindByNameAsync("admin") == null)
      //  {
      //    var user = new ApplicationUser();
      //    user.UserName = "admin";
      //    user.Email = "admin@gmain.com";
      //    var userPassword = "Admin@123";
      //    var chkUser = await userManager.CreateAsync(user, userPassword);
      //    if (chkUser.Succeeded)
      //    {
      //      await userManager.AddToRoleAsync(user, "Admin");
      //    }
      //  }
      //  //Create Employee User
      //  if (await userManager.FindByNameAsync("employee") == null)
      //  {
      //    var user = new ApplicationUser();
      //    user.UserName = "employee";
      //    user.Email = "employee@gmail.com";
      //    var userPassword = "Admin@123";
      //    var chkUser = await userManager.CreateAsync(user, userPassword);
      //    if (chkUser.Succeeded)
      //    {
      //      await userManager.AddToRoleAsync(user, "Employee");
      //    }

      //  }

      //}


      app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
