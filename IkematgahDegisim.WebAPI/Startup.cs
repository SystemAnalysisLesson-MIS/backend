using System;
using System.Threading.Tasks;
using IkematgahDegisim.Core.Extensions;
using IkematgahDegisim.Core.ServiceDependencyResolver;
using IkematgahDegisim.Core.Utilities.Ioc;
using IkematgahDegisim.Core.Utilities.Security.Encryption;
using IkematgahDegisim.Core.Utilities.Security.Jwt.Entities;
using IkematgahDegisim.DataAccess.Concerete.EntityFramework.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Autofac;
using IkematgahDegisim.Core.Utilities.Handlers._Exception;
using Microsoft.AspNetCore.Http;

namespace IkematgahDegisim.WebAPI
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;

            });

           

            services.AddDbContext<IkematgahDegisimContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IkematgahDegisimContext")));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:3000"));
            });

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };


                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                throw new SecurityTokenExpiredException();
                            }
                            return Task.CompletedTask;
                        }
                    };

                });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.EventsType = typeof(CustomCookieAuthenticationEvents);
            //});




            services.AddDepencyResolver(new ICoreModule[]
            {
                new CoreModule()
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.ConfigureToCustomExceptionMiddleware();

            app.UseExceptionHandler("/errors/500");

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            //app.UseStatusCodePages(async context =>
            //{
            //    if (context.HttpContext.Request.Path.StartsWithSegments("/api"))
            //    {
            //        // fallback when no content is provided in an api response
            //        if (!context.HttpContext.Response.ContentLength.HasValue ||
            //            context.HttpContext.Response.ContentLength == 0)
            //        {
            //            if (context.HttpContext.Response.StatusCode == 401)
            //            {
            //                await context.HttpContext.Response.WriteAsync(new Error()
            //                {
            //                    error = new AuthenticateErrorDetails
            //                    {
            //                        code = context.HttpContext.Response.StatusCode,
            //                        message = "Unauthorized"
            //                    }
            //                }.ToString());
            //            }
            //        }
            //    }
            //});


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
