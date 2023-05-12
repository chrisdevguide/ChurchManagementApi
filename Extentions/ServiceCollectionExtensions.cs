using ChurchManagementApi.Data;
using ChurchManagementApi.Data.Repositories.Implementations;
using ChurchManagementApi.Services.Implementations;
using ChurchManagementApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;


namespace ChurchManagementApi.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                });


            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Program));
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddCors((options) =>
            {
                options.AddDefaultPolicy(builder => { builder.WithOrigins((isDevelopment) ? "http://localhost:4200" : "https://ministrymanager-1.web.app").AllowAnyHeader().AllowAnyMethod(); });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });

            services.AddScoped<IIdentityServices, IdentityServices>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IChurchUserRepository, ChurchUserRepository>();
            services.AddScoped<IMemberServices, MemberServices>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupServices, GroupServices>();
            services.AddScoped<IAutomatedEmailRepository, AutomatedEmailRepository>();
            services.AddScoped<IAutomatedEmailServices, AutomatedEmailServices>();
            services.AddScoped<IEmailServices, EmailServices>();
            services.AddScoped<IChurchEventRepository, ChurchEventRepository>();
            services.AddScoped<IChurchEventServices, ChurchEventServices>();
            services.AddHostedService<EmailBackgroundService>();
        }
    }
}
