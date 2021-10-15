using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SEDC.NotesApp.Api.Services;
using SEDC.NotesApp.Services;
using SEDC.NotesApp.Services.Helpers;
using SEDC.NotesApp.Services.Interface;
using System.Text;

namespace SEDC.NotesApp.Api
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
            // Options pattern implementation
            // Configure AppSettings secion
            var appConfig = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appConfig);

            // Using AppSettings class
            var appSettings = appConfig.Get<AppSettings>();
            string connString = appSettings.NoteAppConnectionString;

            byte[] secret = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddControllers();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using Bearer scheme"
                });
                options.AddSecurityDefinition("exampleAuth", new OpenApiSecurityScheme
                {
                    Name = "Example Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "example",
                    In = ParameterLocation.Header,
                    Description = "This is some example scheme"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                               Reference=new OpenApiReference
                               {
                                   Type=ReferenceType.SecurityScheme,
                                   Id="bearerAuth"
                               }
                        },
                        new string[]{}
                    }
                });
            });

            DIModule.RegisterModule(services, connString);

            //registering services
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
