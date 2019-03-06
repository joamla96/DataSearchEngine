using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataSearchContain.Api.Models;
using DataSearchContain.Application.Commands;
using DataSearchContain.Domain.UnitOfWork;
using DataSearchContain.Infrastructure.UnitOfWork;
using EasyNetQ;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DataSearchContain.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

			IPAddress[] addresslist = Dns.GetHostAddresses(Dns.GetHostName());
			IBus bus;
			var me = new ServiceOption() {
				//Host = addresslist[]??,
				PathBase = new Microsoft.AspNetCore.Http.PathString("SearchContain"),
			};

			using(bus = RabbitHutch.CreateBus("host=ssh.jalawebs.com;persistentMessages=false")) {
				bus.Send("DataSearchContainInstances", me);
			}
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddMediatR(typeof(Command));
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
