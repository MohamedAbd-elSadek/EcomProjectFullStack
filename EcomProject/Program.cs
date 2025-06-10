
using EcomProject.BL;
using EcomProject.DAL;
using EcomProject.DAL.Context;
using EcomProject.DAL.Models;
using EcomProject.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EcomProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMemoryCache();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // <-- Angular URL
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });



            #region Auth 
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.Cookie.Name = "token";
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
            }).AddJwtBearer(op =>
            {
                op.RequireHttpsMetadata = false;
                op.SaveToken = true;
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Secret"])),
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Token:Issuer"],
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                };
                op.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["token"];
                        return Task.CompletedTask;
                    }
                };
                });

            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{

            //    var secretKey = builder.Configuration.GetValue<string>("Secret");
            //    var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            //    var key = new SymmetricSecurityKey(secretKeyBytes);

            //    options.TokenValidationParameters = new()
            //    {
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        IssuerSigningKey = key
            //    };
            //});
            #endregion

            #region Identity
            builder.Services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;

            })
                .AddEntityFrameworkStores<EcommDBContext>()
                .AddDefaultTokenProviders();


            #endregion

            DataAccessExtensions.AddDataAccessExtensions(builder.Services, builder.Configuration);
            BusinessExtensions.AddBussinessExtensions(builder.Services);

            builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                // You can configure identity options here if needed
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<EcommDBContext>();


            var app = builder.Build();
            app.UseCors("AllowAngularApp");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            var imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Attachments");
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(imagesFolder),
                RequestPath = "/attachments"
            });
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
