using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ocelot.Client.Controllers;
using Ocelot.Client.Generator;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using Ocelot.Client.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OcelotConfigurationServiceCollectionExtensions
    {
        /// <summary>
        /// Allow feature for routes generator in Ocelot format        
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddOcelotConfigurationGen(
         this IServiceCollection services)
        {
            services.Configure<MvcOptions>(c =>
                c.Conventions.Add(new OcelotConfigurationConvention()));

            services.AddTransient(CreateOcelotConfigurationProvider);            

            return services;
        }

        private static IOcelotConfigurationProvider CreateOcelotConfigurationProvider(IServiceProvider serviceProvider)
        {
            var provider = serviceProvider.GetRequiredService<IApiDescriptionGroupCollectionProvider>();
            var configuration = new OcelotConfigurationGenerator(provider);
            return configuration;
        }
    }
}
