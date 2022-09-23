using DocumentFormat.OpenXml.Drawing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using ParserServer.Jobs;
using ParserServer.Services;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Path = System.IO.Path;

namespace ParserServer
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var wwwRootPath = Path.GetFullPath("ClientApp/build", _env.ContentRootPath);
            _env.WebRootPath = wwwRootPath;
            _env.WebRootFileProvider = new PhysicalFileProvider(wwwRootPath);

            services.AddHostedService<QuartzHostedService>();
            services.AddSingleton<ParsingService>();
            services.AddSingleton<OfferService>();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSwaggerGen(options => options.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo {Title = "Parser API", Version = "v1"}));

            services.AddSingleton<OwnJob>();
            // services.AddSingleton(new MyJob(type: typeof(OwnJob), expression: "0 0/30 * 1/1 * ? *"));
            services.AddQuartz(q => services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true));

            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "../ClientApp/build"; });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "ParserServer"));

            app.UseHttpsRedirection();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/index.html" && context.Request.Method == "POST")
                {
                    context.Request.Method = "GET";
                }

                await next();
            });

            app.UseDefaultFiles(); // Serve index.html for route "/"

            var staticFileOptions = new StaticFileOptions
            {
                FileProvider = _env.WebRootFileProvider,
                ServeUnknownFileTypes = true
            };
            // app.UseStaticFiles(staticFileOptions);
            app.UseSpaStaticFiles(staticFileOptions);

            // app.UseMiddleware<IspValidatorMiddleware>();

            app.UseRouting();

            app.UseCors(builder => builder
                .WithOrigins(
                    "http://localhost",
                    "http://localhost:4200",
                    "https://localhost",
                    "https://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.DefaultPageStaticFileOptions = staticFileOptions;
                // spa.Options.SourcePath = "ClientApp";
                //
                // if (env.IsDevelopment())
                // {
                //     spa.UseReactDevelopmentServer(npmScript: "start");
                // }
            });
        }
    }
}