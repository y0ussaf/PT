using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Azure.ServiceBus;
using Common.Extensions;
using Common.Messages.Commands;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Subscription.Extensions;

namespace Subscription
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAzureServiceBus(Configuration);
            services.AddMediatR(typeof(Startup));
        }

 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.RegisterCommandsHandlers();
            app.RegisterEventsHandlers();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
        
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}