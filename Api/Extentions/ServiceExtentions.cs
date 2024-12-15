using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DataAccess;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Primitives;
using Application.Interfaces;
using Application.Implement;
using Swashbuckle.AspNetCore.Filters;
using Domain.Helper;
using Api.Helper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
        public static void ConfigureIISInteration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(option =>
            {

            });
        }
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwt = configuration.GetSection("Jwt").Get<JwtSettings>();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(option => {

                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwt.Issuer,
                    ValidAudience = jwt.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey)),
                };
                option.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        StringValues accessToken = context.Request.Query["access_token"];
                        PathString path = context.HttpContext.Request.Path;

                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/signalR"))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName));
            });

        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApplicationUser>(option =>
            {
                option.Password.RequiredUniqueChars = 0;
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedPhoneNumber = false;
                option.SignIn.RequireConfirmedEmail = false;
                option.SignIn.RequireConfirmedAccount = false;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();

        }
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = " API",
                    Version = "v1",
                    Description = " API Created By Ahmed Adel",
                    Contact = new OpenApiContact
                    {
                        Name = "Ahmed Adel",
                        Email = "https://mail.google.com/mail/?view=cm&fs=1&to=ahmedzkazzanova@gmail.com",
                        Url = new Uri("https://www.facebook.com/people/Ahmed-Adel/100009898380220"),

                    },
                });
                s.AddSignalRSwaggerGen();
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                         {
                         new OpenApiSecurityScheme
                         {
                         Reference = new OpenApiReference
                         {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                         },
                         Name = "Bearer",
                         },
                         new List<string>()
                         }
                    });
                s.OperationFilter<SecurityRequirementsOperationFilter>();
            });

        }
        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
        }
        public static void MapEndPoints(this WebApplication app)
        {
            var endPointImplement = typeof(Program).Assembly
                .GetTypes()
                .Where(m => m.IsAssignableTo(typeof(IApiInterface))
                && !m.IsAbstract && !m.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IApiInterface>();

            foreach (var endPoint in endPointImplement)
                endPoint.RegisterEndPoint(app);
        }
    }
}
