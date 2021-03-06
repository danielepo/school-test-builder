﻿using BL;
using BL.Interfaces;
using DAL;
using Entities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuizH.Data;
using QuizH.Models;
using QuizH.Services;

namespace QuizH
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                //builder.AddUserSecrets();
            }
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            var connectionString = Configuration.GetConnectionString("MyConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString)
            );
            var connectionString2 = Configuration.GetConnectionString("MyConnectionEntity");
            services.AddDbContext<EntityDbContext>(options =>
                options.UseSqlite(connectionString2)
            );

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddMediatR();

            services.AddAuthorization(options =>
                options.AddPolicy("Professor", policy => policy.RequireClaim("IsProfessor")));

            // Add application services.
            //DAL
            services.AddSingleton<ICourseRepository, CourseRepository>();
            services.AddSingleton<IExamRepository, ExamRepository>();
            services.AddSingleton<IQuestionRepository, QuestionRepository>();
            services.AddSingleton<IProfessorRepository, ProfessorRepository>();
            services.AddSingleton<ISubjectRepository, SubjectRepository>();
            //BL
            services.AddTransient<IQuestionParser, QuestionParser>();

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, EntityDbContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            if (!env.IsProduction())
            {
                context.Database.EnsureCreated();
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();
            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}