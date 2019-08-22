﻿using LapSimBackend.MongoDb.Model;
using LapSimBackend.MongoDb.Services;
using LapSimBackend.Service.Interfaces;
using LapSimBackend.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LapSimBackend
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
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()));

            services.Configure<LapSimDatabaseSettings>(Configuration.GetSection(nameof(LapSimDatabaseSettings)));

            services.AddSingleton<ILapSimDatabaseSettings>(sp => sp.GetRequiredService<IOptions<LapSimDatabaseSettings>>().Value);

            services.AddSingleton<ITeamsService, TeamsService>();
            services.AddSingleton<IProjectLeadersService, ProjectLeadersService>();
            services.AddSingleton<ISimulationsService, SimulationsService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}