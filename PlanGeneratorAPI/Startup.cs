using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanGeneratorDataAccess;
using PlanGeneratorRepository.Contracts;
using PlanGeneratorRepository.Implementations;

namespace PlanGeneratorAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myPolicy";


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("PlanGeneratorContext");

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDbContext<PlanGeneratorContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeAbsenceDateRepository, EmployeeAbsenceDateRepository>();
            services.AddScoped<IEmployeeShiftRequirementRepository, EmployeeShiftRequirementRepository>();
            services.AddScoped<IWorkPlanGeneratorRepository, WorkPlanGeneratorRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddIdentity<IdentityUser, IdentityRole>(x=>
            {
                x.Password.RequireDigit = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;

            })
                .AddEntityFrameworkStores<PlanGeneratorContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.Name = "Identity.Cookie";
                option.LoginPath = "/login";
            });
            services.AddAuthorization(option =>
            {
                var defaultAuthBuilder = new AuthorizationPolicyBuilder();
                var defaultAuthPolicy = defaultAuthBuilder.RequireAuthenticatedUser().Build();

                option.DefaultPolicy = defaultAuthPolicy;
            });
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
                app.UseExceptionHandler();
            }
            app.UseStatusCodePages();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
